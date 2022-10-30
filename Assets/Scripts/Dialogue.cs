using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI speechText;

    public string speakerName;
    public string[] lines;
    public float textSpeed;
    
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        speechText.text = string.Empty;
        speakerNameText.text = speakerName;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
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

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            speechText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
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
