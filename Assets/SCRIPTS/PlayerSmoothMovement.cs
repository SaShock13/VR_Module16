using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerSmoothMovement : MonoBehaviour
{
    [SerializeField] private SteamVR_Action_Vector2 joystickInput;
    [SerializeField] private float moveSpeed = 0.5f;
    Vector3 lookDirection;
    CharacterController characterController;

    private void Awake()
    {   
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        var x = joystickInput.axis.x;
        var y = joystickInput.axis.y;
        lookDirection = Player.instance.hmdTransform.TransformDirection(new Vector3(x, 0, y));
        var moveDirection = moveSpeed * Time.deltaTime * (Vector3.ProjectOnPlane(lookDirection, Vector3.up)).normalized;
        characterController.Move(moveDirection - (new Vector3(0,9.8f,0)*Time.deltaTime));
    }
}
