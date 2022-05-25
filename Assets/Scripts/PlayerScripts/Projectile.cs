using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    Vector3 targetPosition;

    public int attackDamage = 10;
    public LayerMask enemyLayers;
    public Transform kickPoint;
    public float kickRange = 0.5f;
    public GameObject BloodExplotion;

    public GameObject destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(kickPoint.position, kickRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            ///print("we hit" + enemy.name);
            enemy.GetComponent<Damageable>().TakeDamage(attackDamage);
            Instantiate(BloodExplotion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
