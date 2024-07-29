using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] Animator doorAnimator ;
    [SerializeField] UnityEvent onButtonPushedEvent;
    Animator buttonAnimator ;
    
    public void Awake()
    {
        buttonAnimator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Heavy"))
        {
            buttonAnimator.SetTrigger("ButtonPushed");
            onButtonPushedEvent?.Invoke();
                          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
