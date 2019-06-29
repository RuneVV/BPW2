using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject inventoryMenu;
    public GameObject questsMenu;
    public GameObject bellCounter;
    public GameObject uitleg;
    public GameObject controlls;

    public GameObject honeyJar;

    public GameObject uitroep;

    GameObject player;

    public FreezeFrame freeze;
    public bool explScene = false;
    public bool ResumeHasPressed = false;
    
    
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "GameScene")
        {
           
            explScene = true;
        }
        optionsMenu.SetActive(false);
        inventoryMenu.SetActive(false);
        questsMenu.SetActive(false);
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
          honeyJar.transform.localPosition = new Vector3(-319f, 63f, 0f);
        }
        

        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale = 0;
            freeze.Freezeframe();
            optionsMenu.SetActive(true);
            bellCounter.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            Time.timeScale = 0;
            freeze.Freezeframe();
            inventoryMenu.SetActive(true);
            bellCounter.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 0;
            freeze.Freezeframe();
            questsMenu.SetActive(true);
            bellCounter.SetActive(false);
        }
        else if (explScene == true && ResumeHasPressed == false)
        {
            Time.timeScale = 0;
            freeze.Freezeframe();
            uitleg.SetActive(true);
            bellCounter.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "endScene")
        {
            Time.timeScale = 0;
            freeze.Freezeframe();
        }
    }

    public void Resume()
    {
        ResumeHasPressed = true;
        Time.timeScale = 1;
        uitleg.SetActive(false);
        questsMenu.SetActive(false);
        inventoryMenu.SetActive(false);
        optionsMenu.SetActive(false);
        bellCounter.SetActive(true);
        controlls.SetActive(false);
        uitroep.transform.localPosition = new Vector3(1455f, 26f, 0f);

        freeze.UnFreezeFrame();
    }

    public void SwitchQ()
    {
        questsMenu.SetActive(true);
        inventoryMenu.SetActive(false);
        optionsMenu.SetActive(false);
        bellCounter.SetActive(false);
    }

    public void SwitchI()
    {
        questsMenu.SetActive(false);
        inventoryMenu.SetActive(true);
        optionsMenu.SetActive(false);
        bellCounter.SetActive(false);
    }

    public void SwitchO()
    {
        questsMenu.SetActive(false);
        inventoryMenu.SetActive(false);
        optionsMenu.SetActive(true);
        bellCounter.SetActive(false);
    }

    public void openControlls()
    {
        controlls.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SecondResume()
    {
        controlls.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void WinGame()
    {
        SceneManager.LoadScene(3);
    }
}
