using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSensibility : PutadaBase
{
    public MouseManager mouse;

    public override void Efecto()
    {
        mouse.increaseSensitivity = true;
    }
    public override void EliminarEfecto()
    {
        mouse.increaseSensitivity = false;
    }

}
