using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private GameObject dlgContainer;
    TextMeshProUGUI _textMeshPro;
    private float opacity, texTimer;

    [TextArea] public string[] desvarios;

    private void Start()
    {
        if (dlgContainer.GetComponent<TextMeshProUGUI>() == null) 
        {
            Debug.Log("Dialogue Container not correct");
        }else
        {
            _textMeshPro = dlgContainer.GetComponent<TextMeshProUGUI>();
        }
    }

    private void Update()
    {
        if (texTimer > 0)
        {
            ReduceOpacity(0.5f * Time.deltaTime);
            texTimer -= Time.deltaTime;
        }
        else
        {
            ReduceOpacity(-0.5f * Time.deltaTime);
        }

        //Esto solo para testear
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateText(3, null);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeLocation();
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

    public void ChangeLocation()
    {
        //Coloca el texto en una posición aleatoria
        int ran = Random.Range(0, 2);
        Vector3 offset = new Vector3(1100, 600, 0);

        if(ran == 0)
        {
            //Colocar texto a la izquierda
            dlgContainer.GetComponent<RectTransform>().position = new Vector3(Random.Range(-500, -200) + offset.x, Random.Range(80, 400) + offset.y, 0);
        }
        else
        {
            //Colocar texto a la derecha
            dlgContainer.GetComponent<RectTransform>().position = new Vector3(Random.Range(500, 200) + offset.x, Random.Range(80, 400) + offset.y, 0);
        }

    }
    public void ReduceOpacity(float reduction)
    {
        #region Set opacity
        opacity += reduction;

        if(opacity < 0)
        {
            opacity = 0;
        }

        if(opacity > 5)
        {
            opacity = 5;
        }
        #endregion

        _textMeshPro.color = new Color(0, 0, 0, opacity);
    }
    public void ActivateText(int howLong, string whatToSay)
    {
        texTimer = howLong;

        if(whatToSay == null)
        {
            int ran2 = Random.Range(0, desvarios.Length);
            Debug.Log(ran2);
            _textMeshPro.text = desvarios[ran2];
        }
    }
}
