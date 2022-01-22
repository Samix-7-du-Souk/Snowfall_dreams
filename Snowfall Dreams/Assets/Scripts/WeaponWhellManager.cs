using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWhellManager : MonoBehaviour
{

    public Animator anim;
    private bool weaponWheelSelected = false;
    public Image selectedItem;
    public Sprite noImage;
    public static int weaponID;
    public static bool GameIsPaused = false;
    public GameObject pauseWhellMenuUI;


    void Start()
    {
        pauseWhellMenuUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("WeapeonWheel"))
        {
            

            if (GameIsPaused)
            {
                Resume();
                weaponWheelSelected = false;

            }
            else
            {
                Pause();
                weaponWheelSelected = !weaponWheelSelected;
            }

        }
        if (weaponWheelSelected)
        {
            anim.SetBool("OpenWeaponWheel", true);
        }
        else
        {
            anim.SetBool("OpenWeaponWheel", false);
        }

        void Resume()
        {
            pauseWhellMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        void Pause()
        {
            pauseWhellMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        switch (weaponID)
        {
            case 0:
                selectedItem.sprite = noImage;
                break;
            case 1: // Epée
                selectedItem.sprite = noImage; // mettre les codes restans comme switch l'arme sur le perso
                break;
            case 2: // Lance
                selectedItem.sprite = noImage; // mettre les codes restans comme switch l'arme sur le perso
                break;
            case 3: // Arc
                selectedItem.sprite = noImage; // mettre les codes restans comme switch l'arme sur le perso
                break;
            case 4: // Marteau
                selectedItem.sprite = noImage; // mettre les codes restans comme switch l'arme sur le perso
                break;
        }

    }
}
