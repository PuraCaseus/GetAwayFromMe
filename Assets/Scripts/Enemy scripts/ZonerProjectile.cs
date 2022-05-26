using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonerProjectile : MonoBehaviour
{

    public float speed;
    Vector3 targetPosition;

    public int attackDamage = 10;
    public LayerMask enemyLayers;
    public Transform kickPoint;
    public float kickRange = 0.5f;
    public GameObject BloodExplotion;


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if(transform.position == targetPosition)
        {
            
            Destroy(gameObject);
            Instantiate(BloodExplotion, transform.position, Quaternion.identity);
        }


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(kickPoint.position, kickRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            ///print("we hit" + enemy.name);
            enemy.GetComponent<PlayerDamaged>().TakeDamage(attackDamage);
            Instantiate(BloodExplotion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }



}
