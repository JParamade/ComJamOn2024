using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PutadaBase : State
{


    private void Start()
    {
        
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


}
