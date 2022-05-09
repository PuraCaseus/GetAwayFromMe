using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamaged : MonoBehaviour
{
    public float healthAmount = 300;
    public GameObject DeathEffect;
    public GameObject HurtEffect;
    public Animator anim;

    public Image HealthBar;

    void update()
    {
        if(healthAmount <= 0)
        {
          Die();
          SceneManager.LoadScene("GameOver");
        }
        
    }
    
    
    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        HealthBar.fillAmount = healthAmount / 300;
        anim.SetTrigger("isHurt");
        Instantiate(HurtEffect, transform.position, Quaternion.identity);
    }
    
    void Die()
    {
        //print("oof");
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
  
    }

    public void Healing(float healPoints) // This is the function we call from the enemy's script to heal the player
    {
        // This makes it so that healing wont "over-heal" the maximum amount (100)
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 300);

        HealthBar.fillAmount = healthAmount / 300;

    }
  
}
