using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PutadaBase : State
{
    public static PutadaBase Instance { get; private set; }


    private void Start()
    {
        if (PutadaBase.Instance != null)
        {
            Destroy(this);
        }
    }


    private void Update()
    {
        Efecto();
    }
    public virtual void Efecto()
    {

    }
    public virtual void EliminarEfecto()
    {

    }
    public override void Enter()
    {
        
    }
    public override void Exid()
    {
        //EliminarEfecto();
    }

    public void ActivateCameraShake()
    {
        this.GetComponent<CameraShake>().enabled = true;
    }

    public void ActivateSensibilityIncrease()
    {
        this.GetComponent<IncreaseSensibility>().enabled = true;
    }


}
