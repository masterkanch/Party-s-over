using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    private PlayerInteractUI playerInteractUI;

    private void Start()
    {
        playerInteractUI = GameObject.Find("Canvas/PlayerInteractUI").GetComponent<PlayerInteractUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach(Collider collider in colliderArray){
                if(collider.TryGetComponent(out ItemInteractable itemInteractable)){
                    playerInteractUI.userInteract = true;

                }
            }
        }
    }

    public (ItemInteractable, string) GetInteractableObject(){
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach(Collider collider in colliderArray){
            if(collider.TryGetComponent(out ItemInteractable itemInteractable)){
                return (itemInteractable, collider.tag);
            }
        }
        return (null, "");
    }
}
