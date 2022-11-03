using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Verdict : MonoBehaviour
{
    [SerializeField] private GameObject dialougueObj;

    private bool check = false;

    private void Update()
    {
        if (check == true && !dialougueObj.activeSelf)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void VedictBtn()
    {
        dialougueObj.SetActive(true);
        check = true;
    }
}
