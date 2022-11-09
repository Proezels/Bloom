using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public GameObject MikoPiece;
    public GameObject player;
    private bool playerEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerEnter == true)
        {
                if (Input.GetKeyDown(KeyCode.E))
            {
                collect();
            }

        }
    }


    void collect()
    {
        player.GetComponent<playerMovement>().pieceCollected = true;
        MikoPiece.SetActive(true);
        
        Destroy(gameObject);
    }

    void OnTriggerEnter (Collider other)
    {
        playerEnter = true;
    }

    void OnTriggerExit (Collider other)
    {
        playerEnter = false;
    }
}
