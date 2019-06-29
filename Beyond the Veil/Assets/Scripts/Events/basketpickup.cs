using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class basketpickup : MonoBehaviour
{

    public GameObject basketOnGround;
    public GameObject dialogueTriggerItems;

    public GameObject honeyBasket;

    public bool basketCollide = false;
    public bool hasPlacedBasket = false;

    AudioSource SparkleSound2;
  

    // Start is called before the first frame update
    void Start()
    {
        basketOnGround.SetActive(true);
        dialogueTriggerItems.SetActive(false);
        SparkleSound2 = GetComponent<AudioSource>();
    }

    private void Update()
    {
        pickUpBasket();

        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            basketCollide = true;


        }

       
    }


    private void pickUpBasket()
    {
        if (!hasPlacedBasket && basketCollide == true && Input.GetKeyDown(KeyCode.E))
        {
            basketOnGround.SetActive(false);
            SparkleSound2.Play();
            honeyBasket.transform.localPosition = new Vector3(-115f, 64f, 0f);
            hasPlacedBasket = true;
            Fungus.Flowchart.BroadcastFungusMessage("BasketPickUp");

            dialogueTriggerItems.SetActive(true);

            

        }
    }




}
