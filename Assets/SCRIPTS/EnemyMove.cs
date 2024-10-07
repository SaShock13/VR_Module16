using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class EnemyMove : MonoBehaviour
{
    private Transform playerTransform;
    private float speed = 1f;
    public bool isAlive = true;

    private void Awake()
    {
        playerTransform = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if (isAlive)
        {
            transform.LookAt(playerTransform.position);
            transform.position += (playerTransform.position - transform.position).normalized * speed * Time.deltaTime; 
        }
    }
}
