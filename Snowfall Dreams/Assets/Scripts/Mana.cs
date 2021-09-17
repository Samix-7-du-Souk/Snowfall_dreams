using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public int mp;      // les point de viesau joeurs    //
    public int numMp; // le nbr de pv max //
    public int fillMp;

    public Image[] manaCell;
    public Sprite fullMp;
    public Sprite useMP;
    public PointDeVie pointDeVie;
    public Image manaFill;

   


    void Update()
    {
        if (mp > numMp)
        {
            mp = numMp;
        }
        for (int x = 0; x < manaCell.Length; x++) // i = nbr de couers afficher//
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
        }
        if ( mp <= 0)
        {
            manaFill = transform.Find("Bar").GetComponent<Image>();
            manaFill.fillAmount = 3f;
           

        }
        if (Input.GetButtonDown("Cure"))
        {
            if (mp >= 5 && pointDeVie.pv < pointDeVie.numPv)
            {
                Heal(5);
            }

        }
        
    
          
        
    }

    public void Heal(int manaUse)
    {

        mp -= manaUse;
        pointDeVie.pv += 2;
        


    }
   
   
}


