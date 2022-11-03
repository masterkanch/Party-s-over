using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterrogateNote : MonoBehaviour
{
    [SerializeField] private GameObject clipboard;
    [SerializeField] private Sprite[] imageList;
    [SerializeField] private string[] textList;
    [SerializeField] private string[] nameList;
    [SerializeField] private Image imageObject;
    [SerializeField] private TextMeshProUGUI textObject;
    [SerializeField] private TextMeshProUGUI nameObject;

    private int index;
    
    private void Start()
    {
        index = 0;
        ChangePerson();
    }

    public void NextPerson()
    {
        if (index >= 4) return;

        index++;
        ChangePerson();
    }

    public void PrevPerson()
    {
        if (index <= 0) return;

        index--;
        ChangePerson();
    }

    public void OpenClipboard()
    {
        clipboard.SetActive(true);
    }

    public void CloseClipboard()
    {
        index = 0;
        ChangePerson();
        clipboard.SetActive(false);
    }

    private void ChangePerson()
    {
        imageObject.sprite = imageList[index];
        nameObject.text = nameList[index];
        textObject.text = textList[index];
    }
}
