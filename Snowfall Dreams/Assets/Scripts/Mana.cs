using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public int mp;      // les point de viesau joeurs    //
    public int numMp; // le nbr de pv max //
    public float maxValue = 100, currentValue, currentValueSlow;
     

    public Image[] manaCell;
    public Sprite fullMp;
    public Sprite useMP;
    public Sprite noMp;
    public PointDeVie pointDeVie;
    public Image manaFill, manaSlow;

  
    void Start()
    {
        currentValue = maxValue;
        currentValueSlow = maxValue;
        mp = numMp;
        
    }


    float t = 0;

  
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
                if (mp > 0)
                {
                    currentValue = maxValue;
                    currentValueSlow = maxValue;

                }
                else
                {
                    manaCell[x].sprite = noMp;
                    currentValue = 100;
                    currentValueSlow = 100;
                    if (Input.GetButtonDown("LOSE"))
                    {
                        loseMp(100);

                    }
                        
                    if (currentValueSlow != currentValue)
                    {
                        currentValueSlow = Mathf.Lerp(currentValueSlow, currentValue, t);
                        t += 1000.0f * Time.deltaTime;
                        
                    }

                }
                manaFill.fillAmount = currentValue / maxValue;
                manaSlow.fillAmount = currentValueSlow / maxValue;
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
  

    public void Heal(int manaUse)
    {

        mp -= manaUse;
        pointDeVie.pv += 2;

    }

    public void loseMp(float lose)
    {
        currentValue -= lose;
        currentValueSlow = currentValue;
    }

}
   


