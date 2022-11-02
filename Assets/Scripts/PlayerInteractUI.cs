using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private GameObject dialogueContainer;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;
<<<<<<< Updated upstream
    public bool userInteract = false;

    private Dialogue dialogue;
    private string[] itemTexts;

    private void Start()
    {
        dialogue = dialogueContainer.GetComponent<Dialogue>();
    }
    
    private void Update(){
        if(playerInteract.GetInteractableObject() != null && !userInteract){
            Show(playerInteract.GetInteractableObject());
        }
        else if (userInteract)
        {
            Interacted();
            userInteract = false;
        }
        else{
=======
    public bool UserInteract = false;
    
    private void Update(){
        if(playerInteract.GetInteractableObject() != null && UserInteract == false){
            Show(playerInteract.GetInteractableObject());
        }else if(UserInteract){
>>>>>>> Stashed changes
            Hide();
        }
        else{
            Hide();
            
        }

    }
    private void Show(ItemInteractable itemInteractable){
        containerGameObject.SetActive(true);
        itemTexts = itemInteractable.GetInteractText();
    }

    private void Hide(){
        containerGameObject.SetActive(false);
<<<<<<< Updated upstream
        dialogueContainer.SetActive(false);
        userInteract = false;
    }

    private void Interacted()
    {
        containerGameObject.SetActive(false);
        dialogue.InteractItem(itemTexts);
        dialogueContainer.SetActive(true);
=======
        //UserInteract = false;
>>>>>>> Stashed changes
    }
}
