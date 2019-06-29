using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bellfalldown : MonoBehaviour
{
    public float fallSpeed;

    
  

    
    void Update()
    {
        

        transform.Translate(Vector3.down * fallSpeed  * Time.deltaTime);
    }

   
}
