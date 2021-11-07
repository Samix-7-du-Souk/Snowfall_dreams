using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DZone : MonoBehaviour
{
    private Animator fadeSystem;
    public PointDeVie pointDeVie;
    public Transform playerSpawn;


    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
            pointDeVie.isInvincible = false;
            pointDeVie.TakeDamage(1);


        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        


    }
    

}
