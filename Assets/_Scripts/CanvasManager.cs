using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    TextMeshProUGUI resourceText;

    private void Awake()
    {
        resourceText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        resourceText.text = GameManager.Instance.actualValue.ToString();
    }
}
