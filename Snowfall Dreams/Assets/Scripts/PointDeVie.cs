using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointDeVie : MonoBehaviour
{
    public int pv;      // les points de vie au joueur
    public int numPv; // le nbr de pv max
    public int extrapv;      // les points de vie extra au joueur
    public int extraNumPv; // le nbr de pv extra max
    public float invincibilityTimeAfterHit = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public bool isInvincible = false;

    public Image[] couers;
    public Sprite fullvie;
    public Sprite zerovie;
    public SpriteRenderer graphics;
    public Image[] extraCouers;
    public Sprite extraFullvie;
    public Sprite extraZerovie;


    void Start ()
    {
        pv = numPv ;
        
    }
    void Update()
    {
        if (pv > numPv)
        {
            pv = numPv;
        }
        for (int i = 0; i < couers.Length; i++) // i = nbr de couers afficher//
        {
            if (pv < 0)
            {
                pv = 0;
            }
            if (i < pv)
            {
                couers[i].sprite = fullvie;
            }
            else
            {
                couers[i].sprite = zerovie;
            }
            if (i < numPv)
            {
                couers[i].enabled = true;
            }
            else
            {
                couers[i].enabled = false;
            }
        }
        if (extrapv > extraNumPv)
        {
            extrapv = extraNumPv;
        }
        for (int y = 0; y < extraCouers.Length; y++) // y = nbr de  extra couers afficher//
        {
            if (extrapv < 0)
            {
                extrapv = 0;
            }
            if (y < extrapv)
            {
                extraCouers[y].sprite = extraFullvie;
            }
            else
            {
                extraCouers[y].sprite = extraZerovie;
            }
            if (y < extraNumPv)
            {
                extraCouers[y].enabled = true;
            }
            else
            {
                extraCouers[y].enabled = false;
            }

            if (Input.GetKeyDown("g"))
            {
                TakeDamage(1);
            }
            
        }





        /* if (pv <= 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } */
    }
    public void TakeDamage(int damage)
    {
        
            if (!isInvincible)
            {
                if (extrapv > 0)
                {

                    extraNumPv -= damage;
                    isInvincible = true;
                    StartCoroutine(InvincibilityFlash());
                    StartCoroutine(HandleInvincibilityDelay());

                }
                else
                {
                    pv -= damage;
                    isInvincible = true;
                    StartCoroutine(InvincibilityFlash());
                    StartCoroutine(HandleInvincibilityDelay());
                }

            }
        }

    

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }

}


