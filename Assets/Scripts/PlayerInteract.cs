using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private PlayerInteractUI playerInteractUI;


=======
    [SerializeField] private TextMeshProUGUI descriptTextMeshProUGUI;
    [SerializeField] private PlayerInteractUI playerInteractUI;
>>>>>>> Stashed changes
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach(Collider collider in colliderArray){
                if(collider.TryGetComponent(out ItemInteractable itemInteractable)){
<<<<<<< Updated upstream
                    itemInteractable.Interact();
                    playerInteractUI.userInteract = true;
=======
                    descriptTextMeshProUGUI.text =  itemInteractable.Interact();
                    playerInteractUI.UserInteract = true;
>>>>>>> Stashed changes
                }
            }
        }
    }

    public ItemInteractable GetInteractableObject(){
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach(Collider collider in colliderArray){
            if(collider.TryGetComponent(out ItemInteractable itemInteractable)){
                return itemInteractable;
            }
        }
        return null;
    }
}
