using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : MonoBehaviour
{   
    [SerializeField] private string[] interactText;
    [SerializeField] private string interactdescript;
    public void Interact(){
        Debug.Log("Interact!");
    }

    public string[] GetInteractText(){
        return interactText;
    }
}
