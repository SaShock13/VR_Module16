using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharqacterSync : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Vector3 offset;
    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {


        Vector3 cameraPosition = cameraTransform.position;
        cameraPosition.y = characterController.transform.position.y;        
        characterController.center = transform.InverseTransformPoint(cameraPosition-offset);


        //characterController.transform.position = new Vector3(bodyTransform.position.x, characterController.transform.position.y,bodyTransform.position.z);
    }
}
