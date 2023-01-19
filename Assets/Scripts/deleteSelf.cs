using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteSelf : MonoBehaviour
{
    void Update()
    {
        if (LuaScript.ending)
        {
            Destroy(gameObject);
        }
    }
}
