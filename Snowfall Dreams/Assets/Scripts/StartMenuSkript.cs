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
    public bool _canPause = true;


    void Start()
    {
        pauseStartMenuUI.SetActive(false);
    }
    void Update()
    {
        var pauseImput = Input.GetButtonDown("Pause");
        if (pauseImput)
        {

            
            
                if (StartGameIsPaused)
                {
                    Resume();


                }
                else 
                {
                    if (_canPause)
                    {
                        Pause(true);

                    }
                    

                }
            
            

        }

    }
    void Resume()
    {
        pauseStartMenuUI.SetActive(false);
        Time.timeScale = 1f;
        StartGameIsPaused = false;
        MenuIsActiv = false;
        _canPause = true;
    }

    public void Pause(bool state)
    {
        pauseStartMenuUI.SetActive(true);
        Time.timeScale = 0f;
        StartGameIsPaused = true;
        MenuIsActiv = state;
        _canPause = false;
    }
}
