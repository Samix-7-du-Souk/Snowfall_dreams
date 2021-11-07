using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public int mp;      // les point de viesau joeurs    //
    public int numMp; // le nbr de pv max //
    public Animator anim;
    public float manaRefresch = 30f;
    


    public Image[] manaCell;
    public Sprite fullMp;
    public Sprite useMP;
    public Sprite noMp;
    public PointDeVie pointDeVie;
 



    void Start()
    {
        
        mp = numMp;
        anim = GetComponent<Animator>();
        

    }

  
    void Update()
    {
        if (mp > numMp)
        {
            mp = numMp;
        }

        
        for (int x = 0; x < manaCell.Length; x++) // x = nbr de mp afficher
        {
            
            if (x < mp)
            {
                manaCell[x].sprite = fullMp;
            }
            else
            {
                manaCell[x].sprite = useMP;
            }
            if (x < numMp)
            {
                manaCell[x].enabled = true;
            }
            else
            {
                manaCell[x].enabled = false;
            }
            
            {
                if (mp <= 0)
                {

                    manaCell[x].sprite = noMp;
                    StartCoroutine(ReFill());



                }

            }
            
     
        }


        if (Input.GetButtonDown("Cure"))
        {
            if (mp >= 5 && pointDeVie.pv < pointDeVie.numPv)
            {
                Heal(5);
            }

        }




    }

    public IEnumerator ReFill()
    {
        anim.Play("barMana");
        yield return new WaitForSeconds(manaRefresch);
        




        mp = numMp;


    }


    public void Heal(int manaUse)
    {

        mp -= manaUse;
        pointDeVie.pv += 2;

    }

}
   


