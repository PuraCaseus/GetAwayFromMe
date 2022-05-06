using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamaged : MonoBehaviour
{
    public int maxHealth = 100;
    int health;
    public GameObject DeathEffect;
    public GameObject HurtEffect;
    public Animator anim;

    public HealthBarBehavior Healthbar;
    
    void Start()
    {
        health = maxHealth;
        Healthbar.SetHealth(health, maxHealth);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Healthbar.SetHealth(health, maxHealth);
        anim.SetTrigger("isHurt");
        Instantiate(HurtEffect, transform.position, Quaternion.identity);
        if(health <= 0)
        {
            Die();
            SceneManager.LoadScene("GameOver");
        }
    }
    void Die()
    {
        //print("oof");
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
  
    }

    
}
