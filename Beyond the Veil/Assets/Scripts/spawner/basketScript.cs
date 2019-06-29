using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketScript : MonoBehaviour
{
    public GameObject Basket;
    public bool basketActive = false;

    void Start()
    {
        Basket.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && basketActive == false)
        {
            Basket.SetActive(true);
            basketActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.B) && basketActive == true)
        {
            Basket.SetActive(false);
            basketActive = false;
        }
    }
}
