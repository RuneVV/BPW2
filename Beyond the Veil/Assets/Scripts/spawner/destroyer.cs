using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    public float lifeTime = 10f;


    // Update is called once per frame
    void Update()
    {
        if(lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            if(lifeTime <= 0 )
            {
                Destruction();
            }
        }

        if(this.transform.position.y <= -10)
        {
            Destruction();
        }
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.name == "destroyer")
        {
            Destruction();
        }
       

    }

    void Destruction()
    {
        this.gameObject.SetActive(false);
    }
}
