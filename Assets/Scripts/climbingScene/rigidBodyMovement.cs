using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidBodyMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;


    public Transform orient;

    float horizontalIn;
    float verticalIn;

    Vector3 moveDir;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb. freezeRotation = true;
    }

    private void Update()
    {
        //ground Check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        myInput();
        speedControl();

        //handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else 
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void myInput()
    {
        horizontalIn = Input.GetAxisRaw("Horizontal");
        verticalIn = Input.GetAxisRaw("Vertical");
    }

    private void movePlayer()
    {
        moveDir = orient.forward * verticalIn + orient.right * horizontalIn;

        rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
