using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharqacterSync : MonoBehaviour
{
    [SerializeField] Transform bodyTransform;
    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        characterController.transform.position = new Vector3(bodyTransform.position.x, characterController.transform.position.y,bodyTransform.position.z);
    }
}
