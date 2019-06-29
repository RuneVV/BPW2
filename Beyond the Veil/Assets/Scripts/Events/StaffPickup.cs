using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaffPickup : MonoBehaviour
{

    public GameObject staffOnGround;
    public GameObject staffIcon;

    public bool staffCollide = false;
    public bool hasPlacedStaff = false;
    AudioSource sparkleSound;

    // Start is called before the first frame update
    void Start()
    {
        staffOnGround.SetActive(true);
        sparkleSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        pickUpStaff();

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            staffCollide = true;
            

        }
    }


    private void pickUpStaff()
    {
        if (!hasPlacedStaff && staffCollide == true && Input.GetKeyDown(KeyCode.E))
        {
            staffOnGround.SetActive(false);
            sparkleSound.Play();
            staffIcon.transform.localPosition = new Vector3(-319f, 63f, 0f);

            hasPlacedStaff = true;
            
            
        }
    }
}
