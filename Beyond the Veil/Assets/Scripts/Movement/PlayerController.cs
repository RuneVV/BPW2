using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float sprintSpeed = 10.0f;

    bool onGround = true;
    bool canDoubleJump = false;

    public float CurrentStamina = 20.0f;
    public float MaxStamina = 20.0f;

    public bool playerInputEnabled = true;
    public bool isWalking = false;

    public Slider staminaBar;

    AudioSource running;

    public static PlayerController Instance;

    void Awake()
    {
        if (Instance != null)
            Destroy(Instance);
        Instance = this;
    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        staminaBar.value = CalculateHealth();
        running = GetComponent<AudioSource>();
        running.Play();
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -10f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void Update()
    {
        
        
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);
        isWalking = true;

           
        
        

        if (Input.GetKey(KeyCode.LeftShift) && CurrentStamina >= 0f)
        {
            speed = sprintSpeed;
            CurrentStamina -= Time.deltaTime * 2;
            running.UnPause();
            staminaBar.value = CalculateHealth();

        }
        else
        {
            speed = 6.0f;
            StartCoroutine(CountUpToMaxStamina());
            staminaBar.value = CalculateHealth();
            running.Pause();
        }


       



        RaycastHit hit;
        Vector3 physicsCentre = this.transform.position + this.GetComponent<CapsuleCollider>().center;
               
        if (Physics.Raycast(physicsCentre, Vector3.down, out hit, 1.5f))
        {
            if (hit.transform.gameObject.tag != "Player")
            {
                onGround = true;
            }
        }
        else
        {
            onGround = false;
        }
        


        if(Input.GetKeyDown("space") && !onGround && canDoubleJump)
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
            canDoubleJump = false;
        }
        else if (Input.GetKeyDown("space") && onGround)
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
            canDoubleJump = true;
        }


        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }

    float CalculateHealth()
    {
        return CurrentStamina / MaxStamina;
    }

    IEnumerator CountUpToMaxStamina()
    {
        CurrentStamina += Time.deltaTime *  2; 
        CurrentStamina = Mathf.Clamp(CurrentStamina, 0f, MaxStamina);
        yield return null;
    }



    
}

