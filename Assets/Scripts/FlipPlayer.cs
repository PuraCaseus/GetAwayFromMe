using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayer : MonoBehaviour
{
    public GameObject pivot;

    private Aiming aimScript;

    void Start()
    {
        //Reference to the Aiming script
        aimScript = pivot.GetComponent<Aiming>();
    }

    void FixedUpdate()
    {
        //Flip player
        if (aimScript.lookDirection < -90 || aimScript.lookDirection > 90)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

}