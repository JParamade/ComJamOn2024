using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutadaBase : State
{
    public float Duracion;
    public Enums Type;


    public virtual void Efecto()
    {

    }
    public virtual void EliminarEfecto()
    {

    }
    public override void Enter()
    {
        Efecto();
    }
    public override void Exid()
    {
        EliminarEfecto();
    }


}
