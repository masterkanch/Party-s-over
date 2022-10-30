using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDialogue : MonoBehaviour
{
    public GameObject[] Dialogue { get { return dialogues.Dialogue; } }
    public Dialogues dialogues;

    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkActivate();
    }

    void checkActivate()
    {
        int lengthObject = Dialogue.Length - 1;
        try
        {
             if (Dialogue[index].activeSelf == false && index <= lengthObject)
            {
                index++;
            }
            if (Dialogue[index - 1].activeSelf == false && index <= lengthObject)
            {
                Dialogue[index].SetActive(true);
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

    [System.Serializable]
    public class Dialogues
    {
        public GameObject[] Dialogue;
    }
}
