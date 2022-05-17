using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public LayerMask enemyLayers;
    public Transform kickPoint;

    public float kickRange = 0.5f;
    public int attackDamage = 10;

    public float kickRate = 2f;
    public GameObject BoomEffect;

    void Awake()
    {
        {
            
            Attack();
            Destroy(gameObject);
            Instantiate(BoomEffect, transform.position, Quaternion.identity);

        }
    }
    
    void Update()
    {

    }

    void Attack(){

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(kickPoint.position, kickRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            ///print("we hit" + enemy.name);
            enemy.GetComponent<Damageable>().TakeDamage(attackDamage);
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (kickPoint == null)
            return;
        Gizmos.DrawWireSphere(kickPoint.position, kickRange);
    }

}
