using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonerAI : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;
    public Animator anim;

    public GameObject projectile;
    public float timeBetweenShots;
    public float nextShotTime;

    public float aggroRange;

    Vector2 targetPosition;


    void Update()
    {
      targetPosition = FindObjectOfType<PlayerDamaged>().transform.position;
      float DistToTarget = Vector2.Distance(transform.position, target.position);
      if(DistToTarget < aggroRange)
      {
        ShotCooldown();
      }
       
      if(Vector2.Distance(transform.position, target.position) < minimumDistance)
      {
        transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        anim.SetBool("isRunning", true);
      }
      else
      {
        anim.SetBool("isRunning", false);
      }


    }

    void ShotCooldown()
    {
      
      if(Time.time > nextShotTime)
      {
        Instantiate(projectile, transform.position, Quaternion.identity);
        nextShotTime = Time.time + timeBetweenShots;
      }
    }



}
