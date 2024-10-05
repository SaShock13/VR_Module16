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
            BrokeGlass();
        }
    }

    public void BrokeGlass()
    {
        brokenGlass.SetActive(true);
        gameObject.SetActive(false);
        Destroy(gameObject);
        Destroy(brokenGlass, 1.5f);
    }
}
