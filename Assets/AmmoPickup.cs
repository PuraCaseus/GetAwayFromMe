using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int worth = 100;
    //public GameObject pickupEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        Destroy(gameObject);
        //Instantiate(pickupEffect,transform.position, Quaternion.identity);
        AmmoScript.instance.IncreaseAmmo(worth);
    }

}
