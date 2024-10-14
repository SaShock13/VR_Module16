using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guikiotine : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject man;
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject head;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void GuiliotineActivation()
    {
        animator.SetTrigger("Activation");

    }

    public void ManDecapitate()
    {
        man.SetActive(false);
        head.SetActive(true);
        body.SetActive(true);
    }

}
