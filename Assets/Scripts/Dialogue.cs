using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [SerializeField] private TextMeshProUGUI speechText;

    [SerializeField] private string speakerName;
    [SerializeField] private string[] speechList;
    [SerializeField] private float textSpeed = 0.05f;
    
    private int index;

    private void Start()
    {
        speechText.text = string.Empty;
        speakerNameText.text = speakerName;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (speechText.text == speechList[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                speechText.text = speechList[index];
            }
        }
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in speechList[index].ToCharArray())
        {
            speechText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < speechList.Length - 1)
        {
            index ++;
            speechText.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            gameObject.SetActive(false);
            index = 0;
        }
    }
}
