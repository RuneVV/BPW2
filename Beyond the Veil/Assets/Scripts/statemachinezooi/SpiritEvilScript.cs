using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SpiritEvilScript : MonoBehaviour
{
    public enum States { Intro, Idle, Running, Loop, Caught }
    public States CurrentState = States.Intro;
    public float MaximaleAfstand = 5f;

    public GameObject portal;
    public GameObject PortalPlane;
    public bool MessagePlayed = false;
    private bool isCaught = false;

    void StartRunning()
    {
        //al je shit
        ChangeAnimations(States.Running);
    }

    void ChangeAnimations(States _state)
    {
        CurrentState = _state;

        GetComponent<Animator>().SetInteger("AnimationIndex", (int)CurrentState);



    }

    public void Update()
    {
        Afstand();
    }

    public void Afstand()
    {
        Debug.Log(Vector3.Distance(PlayerController.Instance.transform.position, transform.position));

        if (Vector3.Distance(PlayerController.Instance.transform.position, transform.position) < MaximaleAfstand && CurrentState < States.Running)
        {
            StartRunning();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isCaught == false)
        {

            isCaught = true;
            ChangeAnimations(States.Caught);
            Destroy(gameObject);
            if(MessagePlayed == false)
            {
                Fungus.Flowchart.BroadcastFungusMessage("Caught");
                MessagePlayed = true;
            }
            portal.SetActive(true);
            PortalPlane.SetActive(true);

        }
    }

}
