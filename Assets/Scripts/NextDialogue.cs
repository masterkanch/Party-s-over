using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDialogue : MonoBehaviour
{
    [SerializeField] private GameObject[] Dialogues;

    private int index = 0;

    private void Update()
    {
        checkActivate();
    }

    private void checkActivate()
    {
        int lengthObject = Dialogues.Length - 1;
        try
        {
             if (Dialogues[index].activeSelf == false && index <= lengthObject)
            {
                index++;
            }
            if (Dialogues[index - 1].activeSelf == false && index <= lengthObject)
            {
                Dialogues[index].SetActive(true);
            }
            else if (index == lengthObject + 1)
            {
                gameObject.SetActive(false);
                index = 0;
            }
        }
        catch (System.Exception)
        {}
    }
}
