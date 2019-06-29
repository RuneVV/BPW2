using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TriggerDialogueStart : MonoBehaviour
{
    public GameObject dissapearroot2;
    public GameObject helpQuest;
    public GameObject uitroep;


    public void Start()
    {
        dissapearroot2.SetActive(false);

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            Fungus.Flowchart.BroadcastFungusMessage("StartStartDialogue");
            dissapearroot2.SetActive(true);
            gameObject.SetActive(false);
            helpQuest.transform.localPosition = new Vector3(-124f, 74f, 0f);
            uitroep.transform.localPosition = new Vector3(-200f, 26f, 0f);
        }
    }
}
