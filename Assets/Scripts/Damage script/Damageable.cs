using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public GameObject DeathEffect;
    public GameObject HurtEffect;
    public Animator anim;
    
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("isHurt");
        Instantiate(HurtEffect, transform.position, Quaternion.identity);
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //print("oof");
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
  
    }

    
}
