using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SafeBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numScreen;

    private int[] answers = {1, 1, 0, 4, 1, 9, 9, 7};
    private ArrayList inputList = new ArrayList();
    private bool submit = false;
    private bool correctAns = false;
    private bool isOpen = false;

    private void Update()
    {
        CheckAnswer();
    }

    public void NumClick(int num)
    {
        if (inputList.Count >= answers.Length) return;

        inputList.Add(num);
        numScreen.text += num;
    }

    public void BottonClick(string btn)
    {
        if (btn == "Submit")
        {
            submit = !submit;
        }
        else if (btn == "Delete")
        {
            try
            {
            inputList.RemoveAt(inputList.Count-1);
            numScreen.text = numScreen.text.Remove(numScreen.text.Length-1, 1);
            }
            catch (System.Exception)
            {}
        }
    }

    private void CheckAnswer()
    {
        /*Compare input list with answer*/
        if (answers.Length == inputList.Count && submit && !correctAns)
        {
            for (int i = 0; i <= answers.Length-1; i++)
            {
                int check = (int) inputList[i];
                if (check != answers[i])
                {
                    inputList.Clear();
                    numScreen.text = "";
                    break;
                }
                else if (i == answers.Length-1 && check == answers[i])
                {
                    correctAns = !correctAns;
                }
            }
        }

        if (correctAns && !isOpen)
        {
            Debug.Log("It's open!");
            isOpen = !isOpen;
        }
        else if(submit && !correctAns)
        {
            submit = !submit;
        }
    }
}
