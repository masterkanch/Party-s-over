using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockPick : MonoBehaviour
{
    [SerializeField] private GameObject lockObject;
    [SerializeField] private TextMeshProUGUI[] indexText;

    private int[] key = {5, 2, -3, 4};
    private ArrayList answers = new ArrayList();
    private int keyIndex = 0;
    private int adjustLock = 0;

    private void Update()
    {
        if (gameObject.tag == "Puzzle")
        {
            DoorPick();
        }
        
    }

    private void DoorPick()
    {
        // Adjust lock
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (adjustLock >= 5) return;

            adjustLock++;
            // keyOrder.text = lockIndex.ToString();
            CheckAnswer();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (adjustLock <= -5) return;

            adjustLock--;
            // keyOrder.text = lockIndex.ToString();
            CheckAnswer();
        }

        // Next lock
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (keyIndex <= 0) return;

            adjustLock = 0;
            keyIndex--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (keyIndex >= key.Length - 1) return;

            adjustLock = 0;
            keyIndex++;
        }
    }

    private void CheckAnswer()
    {
        if (adjustLock == key[keyIndex])
        {
            Debug.Log("Ding!");
            indexText[keyIndex].color = Color.green;
            answers.Insert(keyIndex, 0);
        }
        else 
        {
            try
            {
                if (answers.Count > 0)
                {
                    indexText[keyIndex].color = Color.white;
                    answers.RemoveAt(keyIndex);
                }
            }
            catch (System.Exception)
            {}
            Debug.Log(answers.Count);
        }
        
        // Check when done all lock
        if (answers.Count == key.Length)
        {
            Debug.Log("Dong!");
            lockObject.SetActive(false);
            gameObject.tag = "Clue";
        }
    }
}
