using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleTracking : MonoBehaviour
{
    public static int posID = Shader.PropertyToID("_pos");

    public Material iceMat;
    public Camera cam;

    void Update()
    {
        var view = cam.WorldToViewportPoint(transform.position);
        iceMat.SetVector(posID, view);
    }
}
