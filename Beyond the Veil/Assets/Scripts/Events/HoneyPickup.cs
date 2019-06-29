using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class HoneyPickup : MonoBehaviour
{
    public GameObject myHoney;
    public GameObject honeyOnGround;

    public GameObject honeyIcon;

    public bool honeyCollide = false;
    public bool hasPlaced = false;
    public bool NotifHasPlaced = true;

    public GameObject AnnoyingRoot;


    public GameObject StartQuest;
    public GameObject AwakeQuest;

    public GameObject AlertQuestIcon;

    AudioSource sparkle;
    

    


    void Start()
    {
        honeyOnGround.SetActive(false);
        AnnoyingRoot.SetActive(true);
        sparkle = GetComponent<AudioSource>();

        StartQuest.transform.localPosition = new Vector3(-381.729f, 78f, 0f);
        if(NotifHasPlaced == true)
        {
            AlertQuestIcon.transform.localPosition = new Vector3(-200f, 26f, 0f);
            NotifHasPlaced = false;
        }
        

    }

    private void Update() 
    {
        placeOffering();

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            honeyCollide = true;
            Debug.Log(honeyCollide);
            
        }
    }


    private void placeOffering() 
    {
        if (!hasPlaced && honeyCollide == true && Input.GetKeyDown(KeyCode.E))
        {
            honeyOnGround.SetActive(true);
            sparkle.Play();
            myHoney.SetActive(false);
            honeyIcon.transform.localPosition = new Vector3(684f, 63f, 0f);
            AwakeQuest.transform.localPosition = new Vector3(-381.73f, -42f, 0f);
            AlertQuestIcon.transform.localPosition = new Vector3(-200f, 26f, 0f);
            hasPlaced = true;
            Fungus.Flowchart.BroadcastFungusMessage("StartOffering");
            AnnoyingRoot.SetActive(false);
            
        }
    }
}


