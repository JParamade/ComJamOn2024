using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Resource Value")]

    [Range(0, 999)]
    [SerializeField] float targetValue = 999;
    float actualValue = 999;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        
    }

    public int ActualValue()
    {
        actualValue = Mathf.Lerp(actualValue, targetValue, Time.deltaTime);
        int correctedValue = (it)

        return correctedValue;
    } 
}
