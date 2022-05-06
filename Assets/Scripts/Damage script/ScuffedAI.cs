using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScuffedAI : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;


    
    void Update()
    {
    
      transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    } 
    
}
