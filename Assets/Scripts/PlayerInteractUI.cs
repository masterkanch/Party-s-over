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
    public bool userInteract = false;

    private Dialogue dialogue;
    private string[] itemTexts;

    private void Start()
    {
        dialogue = dialogueContainer.GetComponent<Dialogue>();
    }
    
    private void Update(){
        string tag = playerInteract.GetInteractableObject().Item2;
        if(playerInteract.GetInteractableObject().Item1 != null && !userInteract && tag == "Clue"){
            Show();
            itemTexts = playerInteract.GetInteractableObject().Item1.GetInteractText();
        }
        else if (playerInteract.GetInteractableObject().Item1 != null && !userInteract && tag == "Puzzle")
        {
            // Call puzzle function from ItemInteractable and activate Puzzle UI
            Debug.Log(tag);
            Show();
        }
        else if (userInteract)
        {
            Interacted();
            userInteract = false;
        }
        else{
            Hide();
        }

    }
    private void Show(){
        containerGameObject.SetActive(true);
    }

    private void Hide(){
        containerGameObject.SetActive(false);
        dialogueContainer.SetActive(false);
        userInteract = false;
    }

    private void Interacted()
    {
        containerGameObject.SetActive(false);
        dialogue.InteractItem(itemTexts);
        dialogueContainer.SetActive(true);
    }
}
