using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public Transform mouseFollower;
    private bool increaseSensitivity;
    private float multiplier;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        //Tira un raycast desde el ratón al juego
        RaycastHit hit;
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);

        #region Tirar raycast
        if (Physics.Raycast(rayo, out hit))
        {
            if(!increaseSensitivity)
            {
                if (multiplier > 1) multiplier -= Time.deltaTime;
                mouseFollower.position = hit.point;
            }
            else
            {
                //Esto causa el efecto de aumento de sensibilidad
                if(multiplier < 2) multiplier += Time.deltaTime;
                mouseFollower.position = hit.point * multiplier;
            }
            if (hit.collider.CompareTag("Patron")) Debug.Log(1);
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(increaseSensitivity)
            {
                increaseSensitivity = false;
            }
            else
            {
                multiplier = 1;
                increaseSensitivity = true;
            }
        }
    }
}
