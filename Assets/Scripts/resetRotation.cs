using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetRotation : MonoBehaviour
{
    public GameObject Lua;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3 (transform.eulerAngles.x, Lua.transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
