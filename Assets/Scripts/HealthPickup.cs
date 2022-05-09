using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class HealthPickup : MonoBehaviour {

 PlayerDamaged playerHealth;
 public float healthBonus = 20f;
 public HealthBarBehavior value;
 public Slider Slider;

  void Awake()
  {
    playerHealth = FindObjectOfType<PlayerDamaged> ();

  }

  void OnTriggerEnter2D(Collider2D col)
  {
   if (playerHealth.health < playerHealth.maxHealth) 

   {
    playerHealth.health = playerHealth.health + healthBonus;
    Destroy (gameObject);
   
   }

  }


}
