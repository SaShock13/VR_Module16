using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnore : MonoBehaviour
{
    [SerializeField] private Collider characterCollider;
    private Collider [] handColliders;
    
    private void Awake()
    {
        handColliders = GetComponentsInChildren<Collider> ();
        foreach (Collider collider in handColliders)
        {
            Physics.IgnoreCollision(characterCollider, collider);
        }
    }
}
