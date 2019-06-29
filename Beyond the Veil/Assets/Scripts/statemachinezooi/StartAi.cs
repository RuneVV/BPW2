using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StartAi : MonoBehaviour
{
    public catching gE;
    public GameObject evilSpirit;

    public GameObject uitroep;
    public GameObject EvilQuest;

    public bool isActive = false;
    public bool MessageSend = false;

    AudioSource EvilLaugh;

    // Start is called before the first frame update
    void Start()
    {
        evilSpirit.SetActive(false);
        EvilLaugh = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gE.gamehasEnded && isActive == false)
        {
            if(MessageSend == false)
            {
                MessageSend = true;
                EvilLaugh.Play();
                Fungus.Flowchart.BroadcastFungusMessage("EvilSpirit");
                EvilQuest.transform.localPosition = new Vector3(164f, 74f, 0f);
                uitroep.transform.localPosition = new Vector3(-200f, 26f, 0f);
            }
            isActive = true;
            
            
            evilSpirit.SetActive(true);

        }
    }
}
