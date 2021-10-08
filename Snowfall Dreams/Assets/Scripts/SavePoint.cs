using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(PolygonCollider2D))]
public class SavePoint : MonoBehaviour

{
    private GameMaster gm;
    public Image[] totemStatus;
    public Sprite TotemOff;
    public Sprite TotemOn;
    public PointDeVie pointDeVie;
    public Mana mana;

   void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("collision");
            totemStatus[1].sprite = TotemOn;
            gm.lastCheckPointPos = transform.position;
            if (Input.GetButtonDown("Interact"))
            {
                pointDeVie.pv = pointDeVie.numPv;
                mana.mp = mana.numMp;
            }
            
           
        }
    }






}

    