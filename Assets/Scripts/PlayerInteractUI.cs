using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;
    
    public bool userInteract = false;

    private string[] itemTexts;
    private GameObject dialogueObject;
    private GameObject puzzleObject;

    private void Start()
    {
        dialogueObject = dialogue.gameObject;
    }
    
    private void Update(){
        string tag = playerInteract.GetInteractableObject().Item2;

        if(playerInteract.GetInteractableObject().Item1 != null && !userInteract && tag == "Clue"){
            Show();
            itemTexts = playerInteract.GetInteractableObject().Item1.GetInteractText();
        }
        else if (playerInteract.GetInteractableObject().Item1 != null && !userInteract && tag == "Puzzle")
        {
            Show();
            puzzleObject = playerInteract.GetInteractableObject().Item1.puzzle;
        }
        else if (userInteract)
        {
            if (tag == "Clue")
            {
                ClueActivate();
            }
            else if (tag == "Puzzle")
            {
                PuzzleActivate();
            }
        }
        else{
            Hide();
        }

    }
    private void Show(){
        if (!dialogueObject.activeSelf || puzzleObject.activeSelf) {containerGameObject.SetActive(true);}

        interactTextMeshProUGUI.text = playerInteract.GetInteractableObject().Item1.itemName;
    }

    private void Hide(){
        containerGameObject.SetActive(false);
        dialogueObject.SetActive(false);
        if (puzzleObject != null) {puzzleObject.SetActive(false);}
        userInteract = false;
    }

    private void ClueActivate()
    {
        containerGameObject.SetActive(false);
        dialogue.InteractItem(itemTexts);
        dialogueObject.SetActive(true);
        userInteract = false;
    }

    private void PuzzleActivate()
    {
        containerGameObject.SetActive(false);
        puzzleObject.SetActive(true);
        userInteract = false;
    }
}
