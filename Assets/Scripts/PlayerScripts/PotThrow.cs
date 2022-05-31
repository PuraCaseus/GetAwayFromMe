using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class PotThrow : MonoBehaviour
{
    public LayerMask enemyLayers;
    public Transform shootPoint;
    public float shootRate = 2f;
    float nextShotTime = 0f;
    public float offset;
    public Text ammoText;
    public GameObject kruka;

    public AmmoScript Ammo;
 
 
    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        
        if(Time.time >= nextShotTime)
        {
          if (Ammo.GetComponent<AmmoScript>().ammo > 0)
           if (Input.GetKeyDown(KeyCode.V))
           { 
            Yeet();
            nextShotTime = Time.time + 1f / shootRate;
            AmmoScript.instance.UseAmmo(1);
           }
        }
 
    }

    void Yeet(){

     if(Ammo.GetComponent<AmmoScript>().ammo >= 1)
     {
      Instantiate(kruka, shootPoint.position, transform.rotation);
     }

    }

}
