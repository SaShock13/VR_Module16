using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [SerializeField] UnityEvent finishEvent;
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Something in the trigger area");
        if(collider.CompareTag("Player"))
        {
            Debug.Log("Player reached the Finish");
            finishEvent?.Invoke();
        }
    }
}
