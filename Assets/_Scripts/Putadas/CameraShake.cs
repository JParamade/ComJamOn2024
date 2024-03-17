using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : PutadaBase
{

    public Transform camTransform;

    public float shakeDuration = 0f;
    public float shakeTotalDuration;

    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    private void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }
        this.GetComponent<CameraShake>().enabled = false;
        shakeTotalDuration = shakeDuration;
    }

    private void OnEnable()
    {
        Debug.Log("CameraShakeEnabled");
        originalPos = camTransform.localPosition;
    }
    public override void Efecto()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = shakeTotalDuration;
            camTransform.localPosition = originalPos;
            Debug.Log("CameraShakeDisabled");
            this.GetComponent<CameraShake>().enabled = false;
        }
    }
}


