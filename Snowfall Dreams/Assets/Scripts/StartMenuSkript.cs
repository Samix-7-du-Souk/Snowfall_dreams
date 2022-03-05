using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartMenuSkript : MonoBehaviour
{

    public static bool StartGameIsPaused = false;
    public GameObject pauseStartMenuUI;
    public WeaponWhellManager weaponWhellManager;
    public GameObject pauseWhellMenuUI;
    public bool MenuIsActiv = false;


    void Start()
    {
        pauseStartMenuUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {

            
            
                if (StartGameIsPaused)
                {
                    Resume();


                }
                else
                {
                    Pause(true);

                }
            
            

        }

    }
    void Resume()
    {
        pauseStartMenuUI.SetActive(false);
        Time.timeScale = 1f;
        StartGameIsPaused = false;
        MenuIsActiv = false;
    }

    public void Pause(bool state)
    {
        pauseStartMenuUI.SetActive(true);
        Time.timeScale = 0f;
        StartGameIsPaused = true;
        MenuIsActiv = state;
    }
}
