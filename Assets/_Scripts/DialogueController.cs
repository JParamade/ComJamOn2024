using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private GameObject dlgContainer;
    TextMeshPro _textMeshPro;

    private void Start()
    {
        if (dlgContainer.GetComponent<TextMeshPro>() == null) 
        {
            Debug.Log("Dialogue Container not correct");
        }else
        {
            _textMeshPro = dlgContainer.GetComponent<TextMeshPro>();
        }
    }
    public void ShowDialogueBox(string dialogue)
    {
        dlgContainer.SetActive(true);
        NextLine(dialogue);
    }

    public void HideDialogueBox() { dlgContainer.SetActive(false); }

    public void NextLine(string dialogue)
    {
        _textMeshPro.text = dialogue;
    }

}
