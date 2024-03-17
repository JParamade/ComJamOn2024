using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDialogue : MonoBehaviour
{
    [TextArea]
    public string text;

    [SerializeField] DialogueController dialogueController;
    public GameObject nextSceneButton;
    [SerializeField] private float timer;

    void Start()
    {
        //Aqui pones el texto del espejo para que aparezca
        dialogueController.ActivateText(100000,text);
        nextSceneButton.SetActive(false);
    }

    private void Update()
    {
        if(dialogueController.textDisplayed)
        {
            nextSceneButton.SetActive(true);
            Destroy(this);
        }
    }
}
