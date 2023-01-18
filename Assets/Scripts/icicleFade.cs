using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icicleFade : MonoBehaviour
{
    private Material mat;
    public float fadeTimer = 0f;
    private float timer = 0f;
    public static bool fading = false;
    public GameObject wall;
    public Material iceMat;
    public GameObject underMat;
    public GameObject iceWall;
    public float endTimer =0f;

    void Start()
    {
        if (iceMat != null)
        {
            iceMat.SetFloat("_fade", endTimer);
        }
        mat = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            mat.SetFloat("_fade", fadeTimer);
            fade();
        }
        else if (!fading)
        {
            mat.SetFloat("_fade", fadeTimer);
            solid();
        }
        if (LuaScript.ending && iceMat != null)
        {
            Destroy(underMat);
            iceMat.SetFloat("_fade", endTimer);
            mat.SetFloat("_fade", fadeTimer);
            endFade();
        }
    }

    void fade()
    {
        if (fadeTimer <=1)
        {
            timer = timer + 1f;
            if (timer == 10)
            {
                fadeTimer = fadeTimer + 0.1f;
                timer = 0f;
            }
        }
        else if (fadeTimer >= 1f && wall != null)
            {
                wall.SetActive(false);
            } 
    }

    void solid()
    {
        if (fadeTimer >= 0f)
        {
            timer = timer + 1f;
            if (timer == 10)
            {
                fadeTimer = fadeTimer - 0.1f;
                timer = 0f;
            }
        }
        if (fadeTimer <= 0f && wall != null)
        {
            wall.SetActive(true);
        }
    }

    void endFade()
    {
        timer = timer + 1f;
        if (timer >= 90)
        {
            if (timer == 100)
            {
                fadeTimer = fadeTimer +0.05f;
                endTimer = endTimer + 0.1f;
                timer = 90f;
            }
        }
        if (endTimer >= 3)
        {
            Destroy(iceWall);
        }
    }
    
    
}
