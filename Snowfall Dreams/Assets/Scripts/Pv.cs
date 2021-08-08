using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pv : MonoBehaviour
{
    public int pv;      // les point de viesau joeurs    //
    public int numPv; // le nbr de pv max //

    public Image[] couers;
    public Sprite fullvie;
    public Sprite zerovie;

    void Update()
    {
        if (pv > numPv)
        {
            pv = numPv;
        }
        for (int i = 0; i < couers.Length; i++) // i = nbr de couers afficher//
        {
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
    }


}


