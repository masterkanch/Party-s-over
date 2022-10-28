using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [SerializeField] private TextMeshProUGUI speechText;
    [SerializeField] private string speakerName;
    [SerializeField] private string[] lines;
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
            if (speechText.text == lines[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                speechText.text = lines[index];
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
        foreach (char c in lines[index].ToCharArray())
        {
            speechText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
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
