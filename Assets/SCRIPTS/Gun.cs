using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Rigidbody _rb;
    private bool _isAtHome = true;
    [SerializeField] private Transform _homeTransform;
    [SerializeField] private float backSpeed = 0.5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        transform.position = _homeTransform.position;
    }

    public void OnAttach()
    {
        Debug.Log("Gun is attached");
        _isAtHome = true;
    }

    public void OnDetach()
    {
        Debug.Log("Gun is detached");
        _isAtHome = false;
    }

    private void FixedUpdate()
    {
        
        if (!_isAtHome) 
        { 
            transform.position = Vector3.Slerp(transform.position,_homeTransform.position,Time.fixedDeltaTime * backSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, _homeTransform.rotation, Time.fixedDeltaTime * backSpeed);
        }

        //if (transform.position == _homeTransform.position) { _isAtHome = true; Debug.Log("AtHome"); }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<GunHome>())
        {
            _isAtHome = true;
        }
    }
}
