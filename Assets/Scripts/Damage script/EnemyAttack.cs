using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public LayerMask enemyLayers;
    private Animator anim;
    public Transform kickPoint;

    public float kickRange = 0.5f;
    public int attackDamage = 10;

    public float kickRate = 2f;
    float nextKickTime = 0f;

    [SerializeField] private AudioSource AttackSound;

    void Start(){
        anim = GetComponent<Animator>();
    }
    
    void Update(){

        if(Time.time >= nextKickTime)
        {
        
            {
                Attack();
                nextKickTime = Time.time + 1f / kickRate;
            }
        }  

    }

    void Attack(){


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(kickPoint.position, kickRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            ///print("we hit" + enemy.name);
            enemy.GetComponent<Damageable>().TakeDamage(attackDamage);
            AttackSound.Play();
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (kickPoint == null)
            return;
        Gizmos.DrawWireSphere(kickPoint.position, kickRange);
    }

}
