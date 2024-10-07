using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TNTButton : MonoBehaviour
{
    public TNT tnt;
    
    private void Start()
    {
        tnt = GetComponentInParent<TNT>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("Button collided");
        tnt.StartTimer();
    }
}
