using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AimControl : MonoBehaviour
{

   // public KeyCode zoomKey;

    //public Transform scopeObj;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<Camera>().fieldOfView = 20;

        }
        if (Input.GetMouseButtonUp(1))
        {
            GetComponent<Camera>().fieldOfView = 60;
        }
    }
}