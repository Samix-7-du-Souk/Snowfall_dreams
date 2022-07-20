using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    
    [SerializeField] public Image cooldown;
    public float manaRefresch = 0.0f; // aka cooldownTime
    public float manaReady = 30.0f; // aka cooldownTimer
    public bool coolingDown = false; // cooldow state

    public int mp;      // player mana points    
    public int numMp; // max mana points 
    //public Animator anim;
    



    public Image[] manaCell; // mp sprites
    public Sprite fullMp;
    public Sprite useMP;
    public Sprite noMp;
    public PointDeVie pointDeVie; // live point script
    
 



    void Start()
    {
        //anim = GetComponent<Animator>();
        mp = numMp;
        coolingDown = false;
        
        cooldown.fillAmount = 0.0f;


    }

  
    void Update()
    {
        

        if (mp > numMp)
        {
            mp = numMp;
        }

        
        for (int x = 0; x < manaCell.Length; x++) // x = number of mp display
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


            if (mp <= 0)
            {

                manaCell[x].sprite = noMp;
                coolingDown = true;
            
            }

        }

        if (coolingDown)
        {
            manaReady = manaRefresch;
            AplyCooldown();
        }
        else
        {
            // cure spell that heals 2 lp for 5 mp
            if (Input.GetButtonDown("Cure"))
            {
                if (mp >= 5 && pointDeVie.pv < pointDeVie.numPv)
                {
                    Heal(5);


                }

            }

        }


    }

   /* public IEnumerator ReFill()
    {
        //anim.Play("barMana");
        yield return new WaitForSeconds(manaRefresch);
        cooldown.fillAmount -= 1.0f / manaRefresch * Time.deltaTime;
        coolingDown = false;





        mp = numMp;


    }*/
    

    public void Heal(int manaUse)
    {

        mp -= manaUse;
        pointDeVie.pv += 2;

    }
    public void AplyCooldown()
    {
        Debug.Log("Start cooldown");
        manaReady -= Time.deltaTime;

        if (manaReady <= 0.0f)
        {
            coolingDown = false;
            cooldown.fillAmount = 0.0f;
            mp = numMp; // reset mp to max
        }
        else
        {
            Debug.Log(" cooldown anim");
            cooldown.fillAmount = manaReady / manaRefresch;
        }
    }

}
   


