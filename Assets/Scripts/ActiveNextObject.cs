using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveNextObject : MonoBehaviour
{
    [SerializeField] private GameObject[] dialogueObj;
    // [SerializeField] private Dialogues dialogues;

    private int index = 0;

    private void Update()
    {
        CheckActivate();
    }

    private void CheckActivate()
    {
        int lengthObject = dialogueObj.Length - 1;
        try
        {
             if (dialogueObj[index].activeSelf == false && index <= lengthObject)
            {
                index++;
            }
            if (dialogueObj[index - 1].activeSelf == false && index <= lengthObject)
            {
                dialogueObj[index].SetActive(true);
            }
            else if (index == lengthObject + 1)
            {
                // This can deactivate UI too
                gameObject.SetActive(false);
                index = 0;
            }
        }
        catch (System.Exception)
        {}
    }
}
