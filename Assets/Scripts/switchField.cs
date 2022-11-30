using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchField : MonoBehaviour
{
    public GameObject Miko;
    public GameObject Lua;

    void OnTriggerEnter (Collider other)
    {
        if (other.name == "Miko")
        {
            Miko.GetComponent<MikoScript>().nearLua = true;
        }
        if (other.tag == "tablet")
        {
            Debug.Log("tablet");
            Lua.GetComponent<LuaScript>().nearTablet = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.name == "Miko")
        {
            Miko.GetComponent<MikoScript>().nearLua = false;
        }

        if (other.tag == "tablet")
        {
            Lua.GetComponent<LuaScript>().nearTablet = false;
        }
    }

}
