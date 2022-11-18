using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    
    public GameObject aura;
    public ParticleSystem aoe;
    public GameObject endFX;
    public GameObject trail;
    public Material snow;
    public float trackDepth;
    public float deepSnow;
    public bool magic = false;
    private bool  endable = false;
    public static bool ending = false;

    public GameObject otherPlayer;
    public GameObject cam;
    public GameObject otherCam;
    public bool nearLua = false;
    public bool nearTablet = false;

    public bool pieceCollected = false;
    public bool tabletFixed = false;
    public GameObject MikoPiece;
    
    private Animator anim;

    //public AudioClip[] footsteps;
    //public float stepTimer = 0f;
    //public float stepSpeed = 100f;
    
    void Start()
    {
    //    anim = gameObject.GetComponent<Animator>();
        snow.SetFloat("_heightMult", trackDepth);
    }

    void Update()
    {

        // character movement
        if (gameObject.name == "Miko")
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
        }
        else if (gameObject.name == "Lua" && !magic)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
        }
        
       // if (controller.velocity != Vector3.zero)
       // {
       //     stepTimer = stepTimer + 1f;
       //     if (stepTimer >= stepSpeed)
       //     {
       //         steps();
       //         stepTimer = 0f;
       //     }
       // }
       // else if (controller.velocity == Vector3.zero)
       // {
       //     stepTimer = 0f;
       // }
       
       // activate aura
       if (gameObject.name == "Lua")
       {
            if (!magic && !endable)
            {
                springMagic();
            }
            else 
            {
                if (!aoe.isPlaying && !endable)
                {
                    aura.SetActive(false);
                    trail.SetActive(true);
                    snow.SetFloat("_heightMult", trackDepth);
                    icicleFade.fading = false;
                    magic = false;
                }
            }
        }

       //switch players 
            
        if (gameObject.name == "Miko" && nearLua == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                otherPlayer.GetComponent<playerMovement>().enabled = true;
                otherCam.SetActive(true);
                gameObject.GetComponent<playerMovement>().enabled = false;
                cam.SetActive(false);
            }

            if (pieceCollected == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    otherPlayer.GetComponent<playerMovement>().pieceCollected = true;
                    pieceCollected = false;
                    MikoPiece.SetActive(false);
                }
            } 
        }
        else if (gameObject.name == "Lua")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                otherPlayer.GetComponent<playerMovement>().enabled = true;
                otherCam.SetActive(true);
                gameObject.GetComponent<playerMovement>().enabled = false;
                cam.SetActive(false);
            }

            if (pieceCollected == true && nearTablet == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    tabletFixed = true;
                }
                if (tabletFixed)
                {
                    endable = true;
                }
                if (tabletFixed &&  Input.GetKeyDown(KeyCode.F))
                {
                    ending = true;
                    snow.SetFloat("_heightMult", deepSnow);
                    endFX.SetActive(true);
                    trail.SetActive(false);
                    
                }
            }
            else if (!nearTablet)
            {
                endable = false;
            }
        }
       
    }

    void springMagic()
    {
        if (Input.GetKeyDown(KeyCode.F))
                {
                    aura.SetActive(true);
                    aoe.Play();
                    trail.SetActive(false);
                    snow.SetFloat("_heightMult", deepSnow);
                    magic = true;
                }
    }

    void stopAnim()
    {
        //anim.enabled = !anim.enabled;
    }

    void steps()
    {
       // AudioSource audio = GetComponent<AudioSource>();
       // audio.clip = footsteps[Random.Range(0, footsteps.Length)];
       // audio.PlayOneShot(audio.clip);
    }
}
