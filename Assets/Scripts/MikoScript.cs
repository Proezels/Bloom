using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikoScript : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    
    public GameObject trail;

    public GameObject otherPlayer;
    public GameObject cam;
    public GameObject otherCam;
    public bool nearLua = false;

    public bool pieceCollected = false;
    public GameObject MikoPiece;
    
    private Animator anim;

    //public AudioClip[] footsteps;
    //public float stepTimer = 0f;
    //public float stepSpeed = 100f;
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        // character movement

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        
       if (controller.velocity != Vector3.zero)
        {
            anim.SetBool("move", true);
        }
        else if (controller.velocity == Vector3.zero)
        {
            anim.SetBool("move", false);
        }

       //switch players 
            
        if (Input.GetKeyDown(KeyCode.Q))
        {
            otherPlayer.GetComponent<LuaScript>().enabled = true;
            otherCam.SetActive(true);
            gameObject.GetComponent<MikoScript>().enabled = false;
            cam.SetActive(false);
        }
        
        if (nearLua)
        {
            //give tablet piece to Lua
            if (pieceCollected == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    otherPlayer.GetComponent<LuaScript>().pieceCollected = true;
                    pieceCollected = false;
                    MikoPiece.SetActive(false);
                }
            } 
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
