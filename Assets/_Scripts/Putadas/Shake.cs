using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : PutadaBase
{
    MouseManager mouse;
    public override void Efecto()
    {
        mouse.shake = true;
    }

    public override void EliminarEfecto()
    {
        mouse.shake = false;
    }
}