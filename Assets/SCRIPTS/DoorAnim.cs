using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
   public void OpenDoor()
   {
        animator.SetTrigger("OpenDoor");
   }
}
