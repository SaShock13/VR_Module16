using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    [SerializeField] private GameObject brokenGlass;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.collider.CompareTag("Heavy"))
        {
            Debug.Log("Heavy Collision");
            brokenGlass.SetActive(true);
            gameObject.SetActive(false);
            Destroy(this, 1.5f); 
        }
    }
}
