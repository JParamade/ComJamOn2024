using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public Transform mouseFollower;
    private MeshRenderer mouseRenderer;

    public bool increaseSensitivity, shake;
    private float multiplierX, multiplierY, outTimer;
    private float Locura;

    public float MultiplierX { get => multiplierX * Locura; set => multiplierX = value; }
    public float MultiplierY { get => multiplierY * Locura; set => multiplierY = value; }

    void Start()
    {
        mouseRenderer = mouseFollower.GetComponent<MeshRenderer>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        multiplierX = 1;
        multiplierY = 1;
    }

    void Update()
    {
        //Tira un raycast desde el ratón al juego
        RaycastHit hit;
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);

        #region Tirar raycast
        if (Physics.Raycast(rayo, out hit))
        {
            #region Debuffs
            if (!increaseSensitivity)
            {
                multiplierX = 0;
                multiplierY = 0;
            }
            else if(!shake)
            {
                //Esto causa el efecto de aumento de sensibilidad
                if (multiplierX < 3) multiplierX += Time.deltaTime;
                if (multiplierY < 3) multiplierY += Time.deltaTime;
            }

            //esto el efecto de shake
            if(shake)
            {
                multiplierX = Random.Range(-0.1f,0.2f);
                multiplierY = Random.Range(-0.1f, 0.2f);
            }

            if(shake || increaseSensitivity)
            {
                if(shake) mouseFollower.position = new Vector3(hit.point.x + MultiplierX, hit.point.y + MultiplierY, hit.point.z);
                if (increaseSensitivity) mouseFollower.position = new Vector3(hit.point.x * MultiplierX, hit.point.y * MultiplierY, hit.point.z);
            }
            else mouseFollower.position = hit.point;
            #endregion

            #region Mirar si Hitteas

            if (hit.collider.CompareTag("Patron"))
            {
                outTimer = 0;
                mouseRenderer.material.color = new Color(0, 0, 255);
                Debug.Log(1);
            }
            else
            {
                if (outTimer < 2.5f) outTimer += Time.deltaTime;

                mouseRenderer.material.color = new Color(outTimer * 10.2f, 0, 255);
                Debug.Log(2);
            }
            #endregion
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (increaseSensitivity)
            {
                increaseSensitivity = false;
            }
            else
            {
                increaseSensitivity = true;
                multiplierX = 1;
                multiplierY = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (shake)
            {
                shake = false;
            }
            else
            {
                shake = true;
            }
        }
    }
}
