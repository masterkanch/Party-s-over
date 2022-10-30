using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockPick : MonoBehaviour
{
    [SerializeField] private GameObject wire;
    [SerializeField] private TextMeshProUGUI keyOrder;
    [SerializeField] private TextMeshProUGUI order;

    private int[] key = {5, 2, -3, 4};
    private ArrayList answers = new ArrayList();
    private int keyIndex = 0;
    private int lockIndex = 0;

    private void Start()
    {
        // wire = GetComponent<RectTransform>();
    }

    private void Update()
    {
        DoorPick();
    }

    private void DoorPick()
    {
        // Adjust lock
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (lockIndex >= 5) return;

            lockIndex++;
            keyOrder.text = lockIndex.ToString();
            CheckAnswer();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (lockIndex <= -5) return;

            lockIndex--;
            keyOrder.text = lockIndex.ToString();
            CheckAnswer();
        }

        // Next lock
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (keyIndex <= 0) return;

            lockIndex = 0;
            keyIndex--;
            order.text = keyIndex.ToString();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (keyIndex >= key.Length - 1) return;

            lockIndex = 0;
            keyIndex++;
            order.text = keyIndex.ToString();
        }
    }

    private void CheckAnswer()
    {
        if (lockIndex == key[keyIndex])
        {
            Debug.Log("Ding!");
            answers.Insert(keyIndex, 0);
        }
        else 
        {
            try
            {
                if (answers.Count > 0)
                {
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
        }
    }
}
