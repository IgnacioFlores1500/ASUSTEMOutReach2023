using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MouseLook;

public class SwitchPlayerCamera : MonoBehaviour
{
    
    public enum TogglePerspective
    {
         firstPerson = 0,
         thirdPerson = 1,
    }

    public TogglePerspective whatPerspective = TogglePerspective.firstPerson;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<SC_FPSController>());
        //    return;


        Debug.Log(other + "first");
        if (whatPerspective  == TogglePerspective.firstPerson)
        {
            other.gameObject.GetComponent<SC_FPSController>().enableThirdPerson = true;
        } else
        {
            other.gameObject.GetComponent<SC_FPSController>().enableThirdPerson = false;
        }
        

        Debug.Log(other);
        //other.GetComponent<SC_FPSController>()
    }
}
