using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : MonoBehaviour
{   
    [SerializeField] public string itemName;
    [SerializeField] private string[] interactText;
    [SerializeField] public GameObject puzzle;

    private void Update()
    {
        if (puzzle != null)
        {
            gameObject.tag = puzzle.tag;
        }
    }

    public string[] GetInteractText(){
        return interactText;
    }

    public string GetInteractDescript(){
        return interactdescript;
    }
}
