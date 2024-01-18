using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbing : MonoBehaviour
{
    [Header("References")]
    public Transform orient;
    public Rigidbody rb;
    public LayerMask whatIsWall;
    public LayerMask whatIsIce;
    public rigidBodyMovement rbMove;
    
    [Header("Climbing")]
    public float climbSpeed;
    public float wallSpeed; 
    public float iceSpeed;
    public float maxClimbTime;
    public float climbTimer;
    public bool iceSlide;

    private bool climbingState;
    
    [Header("Detection")]
    public float detectLength;
    public float sphereCastRadius;
    public float maxWallAngle;
    public float wallAngle;

    private RaycastHit frontWallHit;
    private bool wallFront;
    private bool iceFront;

    private void Update()
    {
        wallCheck();
        StateMachine();

        if (climbingState) midClimb();
    }

    private void StateMachine()
    {
        //start climbing || check if there is a wall, if forward is pressed and if angle is correct
        if (wallFront && Input.GetKey(KeyCode.W) && wallAngle < maxWallAngle)
        {
            climbSpeed = wallSpeed;

            if (!climbingState) startClimb();

        }
        else if (iceFront && !iceSlide && Input.GetKey(KeyCode.W) && wallAngle < maxWallAngle)
        {
            climbSpeed = iceSpeed;

            if (!climbingState && climbTimer > 0) startClimb();

            //timer
            if (climbTimer > 0) climbTimer -= Time.deltaTime;
            if (climbTimer < 0) stopClimb();
        }
        else
        {
            {
                if (climbingState) stopClimb();
            }
        }

        if (iceSlide)
        {
            rb.velocity = new Vector3(rb.velocity.x, -5, rb.velocity.z);
        }
    }

    private void wallCheck()
    {
        //spherecast, similar to raycast but uses a cilinder iso line to cast || physics.spherecast takes in startposition, radius, direction, where the info is stored, length of the spherecast & layermask
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orient.forward, out frontWallHit, detectLength, whatIsWall);
        iceFront = Physics.SphereCast(transform.position, sphereCastRadius, orient.forward, out frontWallHit, detectLength, whatIsIce);
        //makes it so that you can only start climbing if the angle you look at the wall is within a specific angle, might not need this. Is here to be able to differentiate between wallclimb & wallrun
        wallAngle = Vector3.Angle(orient.forward, -frontWallHit.normal);

        if(rbMove.grounded)
        {
            climbTimer = maxClimbTime;
            climbingState = false;
            iceSlide = false;
        }
    }

    private void startClimb()
    {
        climbingState = true;
    }

    private void midClimb()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
    }

    private void stopClimb()
    {
        climbingState = false;
        iceSlide = true;
    }

}
