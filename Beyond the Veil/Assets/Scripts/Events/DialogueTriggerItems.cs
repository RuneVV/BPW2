using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DialogueTriggerItems : MonoBehaviour
{
    public GameObject portalblock;
    public GameObject CatchFey;
    public GameObject uitroep;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            Fungus.Flowchart.BroadcastFungusMessage("BellUitleg");

            portalblock.SetActive(false);
            CatchFey.transform.localPosition = new Vector3(-124.73f, -43f, 0f);
            uitroep.transform.localPosition = new Vector3(-200f, 26f, 0f);
        }


    }
}
