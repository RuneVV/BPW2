using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public GameObject Player;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {

        }
        gameHasEnded = true;
        Player.transform.position = new Vector3(-8, 7, -0.8f);
    }
   
    public void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
