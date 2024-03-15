using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    [Range(0, 999999)]
    [SerializeField] float targetValue;
    public float actualValue;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        actualValue = Mathf.Lerp(actualValue, targetValue, Time.deltaTime);
    }
}
