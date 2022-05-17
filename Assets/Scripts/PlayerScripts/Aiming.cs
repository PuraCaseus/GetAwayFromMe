using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Aiming : MonoBehaviour
{
 
    public GameObject myPlayer;
    public float lookDirection;
    
    public void FixedUpdate()
    {
 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mousePos.Normalize();
        float lookDirection = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookDirection);

 
        if (lookDirection < -90 || lookDirection > 90)
        {
            if(myPlayer.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -lookDirection);
            } else if (myPlayer.transform.eulerAngles.y == 180) {
                transform.localRotation = Quaternion.Euler(180, 180, -lookDirection);
            }
 
        }
 
    }
 
}