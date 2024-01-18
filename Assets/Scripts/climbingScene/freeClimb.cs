using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeClimb : MonoBehaviour
{
    public bool isClimbing;

    private bool inPos;
    private bool isLerping;

    float t;
    
    Vector3 startPos;
    Vector3 targetPos;
    
    Quaternion startRot;
    Quaternion targetRot;
    
    public float posOffset;
    public float offsetWall = 0.3f;
    public float speedMulti = 0.2f;

    Transform helper;
    float delta;


    void Start()
    {
        Init();
    }

    void Update()
    {   
        delta = Time.deltaTime;
        tick(delta);

    }

    public void Init()
    {
        helper = new GameObject().transform;
        helper.name = "Climb Helper";
    }

    public void checkClimb()
    {
        Vector3 origin = transform.position;
        origin.y += 1.4f;
        Vector3 dir = transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(origin, dir, out hit, 5))
        {
            inItClimb(hit);
        }
    }

    void inItClimb(RaycastHit hit)
    {
        isClimbing = true;
        helper.transform.rotation = Quaternion.LookRotation(-hit.normal);
        startPos = transform.position;
        targetPos = hit.point + (hit.normal * offsetWall);
        t = 0;
        inPos = false;
    }

    public void tick(float delta)
    {
        if(!inPos)
        {
            getInPos();
            return;
        }
    }

    void getInPos()
    {
        t += delta;

        if (t > 1)
        {
            t = 1;
            inPos = true;
        }

        Vector3 tp = Vector3.Lerp(startPos, targetPos, t);
        transform.position = tp;
    }

    Vector3 posWithOffset(Vector3 origin, Vector3 target)
    {
        Vector3 direction = origin - target;
        direction.Normalize();
        Vector3 offset = direction * offsetWall;
        return target + offset;
    }

}
