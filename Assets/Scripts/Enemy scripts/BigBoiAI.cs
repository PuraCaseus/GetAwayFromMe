using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoiAI : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;
    public LayerMask enemy;
    public int attackDamage = 10;
    
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } else
        {
            //enemy.GetComponent<EnemyAttack>().TakeDamage(attackDamage);

        }

    




    } 
    
}
