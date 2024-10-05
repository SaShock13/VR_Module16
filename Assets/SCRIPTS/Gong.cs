using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gong : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _gongSound;
    [SerializeField] private GameObject _ghostWall;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _gongSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Heavy")) 
        {
            _animator.SetTrigger("Boom");
            _gongSound?.Play();
            _ghostWall.SetActive(false);
        }
    }
}
