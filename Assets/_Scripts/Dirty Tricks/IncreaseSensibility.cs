using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSensibility : PutadaBase
{
    public float duration = 1f;
    private float totalDuration;



    private void Awake()
    {
        totalDuration = duration;

    }
    public override void Efecto()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }else
        {
            duration = totalDuration;
            this.GetComponent<IncreaseSensibility>().enabled = false;
        }
    }
    private void OnEnable()
    {
        MouseManager.Instance.increaseSensitivity = true;
    }
    private void OnDisable()
    {
        MouseManager.Instance.increaseSensitivity = false;
    }

}
