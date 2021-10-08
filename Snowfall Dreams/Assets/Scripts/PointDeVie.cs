using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointDeVie : MonoBehaviour
{
    public int pv;      // les points de vie au joueur
    public int numPv; // le nbr de pv max
    public bool invisibleFrame = false;

    public Image[] couers;
    public Sprite fullvie;
    public Sprite zerovie;

    
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
        if (pv <= 0) // reset la scene quand je meur
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void TakeDamage(int damage)
    {
        if (!invisibleFrame)
        {
            pv -= damage;
            invisibleFrame = true;
            StartCoroutine(InvincibiltyFlash());
        }

    }
    public IEnumerator InvincibiltyFlash()
    {
        while(invisibleFrame)
        {
            
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(1f);
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(1f);
        }
    }
        
}


