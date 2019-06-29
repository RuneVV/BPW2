using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeFrame : MonoBehaviour
{
    public MouseLook camScript;
    public PlayerController moveScript;

    void Start()
    {
        //camScript = gameObject.GetComponent<MouseLook>();
    }

    public void Freezeframe()
    {
        camScript.enabled = false;
        moveScript.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnFreezeFrame()
    {
        camScript.enabled = true;
        moveScript.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
