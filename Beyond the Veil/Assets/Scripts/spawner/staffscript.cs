using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staffscript : MonoBehaviour
{
    public GameObject staff;
    public bool staffEnabled;

    void Start()
    {
        staff.SetActive(false);
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && staffEnabled == false)
        {
            staff.SetActive(true);
            staffEnabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.X) && staffEnabled == true)
        {
            staff.SetActive(false);
            staffEnabled = false;
        }
    }
}
