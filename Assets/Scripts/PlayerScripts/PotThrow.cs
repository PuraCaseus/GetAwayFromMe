using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PotThrow : MonoBehaviour
{
    public LayerMask enemyLayers;
    public Transform shootPoint;
    public float shootRate = 2f;
    float nextShotTime = 0f;
    public float offset;

    public LucidBar lucidbar;
    public GameObject kruka;
 
 
    private void Update()
    {
 
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        
        if (Input.GetKeyDown(KeyCode.V))
        { 
            Yeet();
            nextShotTime = Time.time + 1f / shootRate;
            LucidBar.instance.UseLucid(33);
        }
        
 
    }

        void Yeet(){

        if(lucidbar.GetComponent<LucidBar>().currentLucid>= 33)
        {
            Instantiate(kruka, shootPoint.position, transform.rotation);
        }

    }
 
}