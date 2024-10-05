using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerSmoothMovement : MonoBehaviour
{
    [SerializeField] private SteamVR_Action_Vector2 joystickInput;
    [SerializeField] private float moveSpeed = 0.5f;
    Vector3 lookDirection;
    CharacterController characterController;

    private PostProcessVolume _volume;
    private Vignette _vignette;

    private void Awake()
    {   
        _volume = FindObjectOfType<PostProcessVolume>();
        _volume.enabled = true;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {       
        var inputDirection = new Vector3(joystickInput.axis.x,0, joystickInput.axis.y);
        lookDirection = Player.instance.hmdTransform.TransformDirection(inputDirection);
        var moveDirection = moveSpeed * Time.deltaTime * (Vector3.ProjectOnPlane(lookDirection, Vector3.up)).normalized;
        characterController.Move(moveDirection - (new Vector3(0,9.8f,0)*Time.deltaTime));
        _volume.profile.TryGetSettings(out _vignette);
        //Debug.Log(x +","+ y);
        _vignette.intensity.value = inputDirection.normalized.magnitude;
    }
}
