using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [Header("Text Components")]
    [SerializeField] TextMeshProUGUI resourceText;

    private void Awake()
    {
        
    }

    private void Update()
    {
        resourceText.text = GameManager.Instance.correctedValue.ToString();
    }
}
