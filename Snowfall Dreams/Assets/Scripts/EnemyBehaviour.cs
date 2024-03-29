﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyBehaviour : MonoBehaviour
{
    
    public float speed;
    public Transform[] waypoints;
    public PointDeVie pointDeVie;

    public int damageOnCollision = 1;

    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        target = waypoints[0];
    }

    private void Reset()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Si l'ennemi est quasiment arrivé à sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }
    }
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("collision");
            pointDeVie.TakeDamage(1);
        }
    }

    
}
