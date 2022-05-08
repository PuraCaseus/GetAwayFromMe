using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScuffedAI : MonoBehaviour
{
    public float speed;
    public Transform target;
    //public float minimumDistance;

    [SerializeField]
    float aggroRange;

    Vector2 movement;
    public Animator anim;



    
    void Update()
    {
      float DistToTarget = Vector2.Distance(transform.position, target.position);
      if(DistToTarget < aggroRange)
      {
        anim.SetBool("isRunning", true);
        ChaseTarget();
      }
      else
      {
        anim.SetBool("isRunning", false);
      }


    }

    void ChaseTarget()
    {
     if(transform.position.x < target.position.x)
      {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, -180, 0);
      }
      else
      {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, 0);
      }
    }


    void StopChasingTarget()
    {

    }
}

