using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public Transform[] Puntos;
    private bool[] confirmations;
    public bool Finish;
    public float distancia;

    void Start()
    {
        confirmations = new bool[Puntos.Length];
    }

    public void CheckPoints(Vector3 POsition)
    {
        int j = 0;
        for (int i = 0; i < Puntos.Length; i++)
        {
            if (Vector3.Distance(Puntos[i].position, POsition) < distancia)
            {
                confirmations[i] = true;
            }
            if (confirmations[i] == true)
            {
                j++;
            }
        }
        if (j == confirmations.Length)
        {
            Finish = true;
        }
    }

}
