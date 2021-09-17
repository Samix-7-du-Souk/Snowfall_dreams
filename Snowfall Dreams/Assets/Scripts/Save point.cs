using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Savepoint : MonoBehaviour

{
    public Image[] totemStatus;
    public Sprite TotemOff;
    public Sprite TotemOn;
    public PointDeVie pointDeVie;
    public Mana mana;

    void Update()
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            { 
                totemStatus[1].sprite = TotemOn;            
                if (Input.GetButtonDown("Interact"))
                {
                    pointDeVie.pv = pointDeVie.numPv;
                    mana.mp = mana.numMp;
                }
            

            
            }
               

        }
        
    }
}

    