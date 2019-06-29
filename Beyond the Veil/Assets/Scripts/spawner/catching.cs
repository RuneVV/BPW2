using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class catching : MonoBehaviour
{
    public Text bell1;
    public Text bell2;
    public Text bell3;

    public float score1 = 0f;
    public float score2 = 0f;
    public float score3 = 0f;

    public float maxScore = 10f;

    public TimedSpawn stopSpawn;
    public TimedSpawn stopSpawn2;
    public TimedSpawn stopSpawn3;
    public TimedSpawn stopSpawn4;
    public TimedSpawn stopSpawn5;

    public GameObject bellIcon1;
    public GameObject bellIcon2;
    public GameObject bellIcon3;

    public bool gamehasEnded;

    public Slider HealthBar;

    public float maxHealth = 100f;
    public float currentHealth = 100f;

    AudioSource sparkle;
    public AudioClip evilClip;
    
   
    

    public void OnTriggerEnter(Collider collision)
    {
        /* if (collision.gameObject.tag == "bell")
         {
             score = score + 1f;
             Debug.Log(score);
         }*/

        switch (collision.gameObject.name)
        {
            case "bell1(Clone)":
                //Debug.Log("bell1");
                if (score1 <= maxScore)
                {
                    score1++;
                    sparkle.Play();
                }
                else if (score1 == maxScore || score1 >= maxScore)
                {
                    bellIcon1.transform.localPosition = new Vector3(9f, 0f, 0f);
                }
                bell1.text = score1 + "/10";
                
                break;
            case "Bell2(Clone)":
                //Debug.Log("bell2");
                if (score2 <= maxScore)
                {
                    score2++;
                    sparkle.Play();
                }
                else if (score2 == maxScore || score2 >= maxScore)
                {
                    bellIcon2.transform.localPosition = new Vector3(0f, 0f, 0f);
                }
                bell2.text = score2 + "/10";
                
                break;
            case "Bell3(Clone)":
                //Debug.Log("bell3");
                if (score3 <= maxScore)
                {
                    score3++;
                    sparkle.Play();
                }
                else if (score3 == maxScore || score3 >= maxScore)
                {
                    bellIcon3.transform.localPosition = new Vector3(-6f, -3f, 0f);
                }
                bell3.text = score3 + "/10";
                
                break;
            case "Bell4(Clone)":
                //Debug.Log("bell4");
                if(currentHealth > 1)
                {
                    sparkle.PlayOneShot(evilClip);
                    currentHealth -= 33f;
                    HealthBar.value = CalculateYourHealth();
                    
                }
                else if (currentHealth < 1)
                {
                    SceneManager.LoadScene("GameScene");
                }
               

                break;
        }
    }

    public void Start()
    {
        HealthBar.value = CalculateYourHealth();
        sparkle = GetComponent<AudioSource>();
        

    }

    public void Update()
    {
        //HealthBar.value = CalculateYourHealth();

        if (score1 >= 10 && score2 >= 10 && score3 >= 10)
        {
            gamehasEnded = true;
            stopSpawn.stopSpawn();
            stopSpawn2.stopSpawn();
            stopSpawn3.stopSpawn();
            stopSpawn4.stopSpawn();
            stopSpawn5.stopSpawn();
        }
    }

    float CalculateYourHealth()
    {
        return currentHealth / maxHealth;
    }
}
