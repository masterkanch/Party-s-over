using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : MonoBehaviour
{   
    [SerializeField] private string interactText;
    [SerializeField] private string interactdescript;
    public string Interact(){
      return interactdescript;
    }

    public string GetInteractText(){
        return interactText;
    }

    public string GetInteractDescript(){
        return interactdescript;
    }
}
