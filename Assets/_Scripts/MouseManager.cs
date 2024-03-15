using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private Camera myCam;
    public Transform mouseFollower;
    void Start()
    {
        myCam = Camera.main;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void Update()
    {
        //Tira un raycast desde el ratón al juego
        RaycastHit hit;
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(rayo, out hit))
        {
            mouseFollower.position = hit.point;
            if (hit.collider.CompareTag("Patron")) Debug.Log(1);
        }
    }
}
