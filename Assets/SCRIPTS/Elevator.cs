using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Elevator : MonoBehaviour
{
    //private CircularDrive[] circularDrives;
    [SerializeField] GameObject platform;
    [SerializeField] Transform lowPosition;
    [SerializeField] Transform highPosition;
    [SerializeField] float speed = 2;
    private bool _isActive = false;
    private MoveState moveState;


    enum MoveState
    {
        Up, Down
    }

    private void Start()
    {
        //circularDrives = GetComponentsInChildren<CircularDrive>();
    }

    private void FixedUpdate()
    {

        if (_isActive)
        {
            Move(moveState);
        }
    }

    
    public void MoveDown()
    {
        if (transform == lowPosition) return;

        moveState = MoveState.Down;
        _isActive = true;
    }

    public void MoveUp()
    {
        if (transform == highPosition) return;
        moveState = MoveState.Up;
        _isActive = true;
    }



    private void Move(MoveState moveState)
    {
        Transform finishTransform = moveState == MoveState.Up ? highPosition:lowPosition;
        platform.transform.position = Vector3.Slerp(platform.transform.position, finishTransform.position, Time.fixedDeltaTime * speed);
        if (platform.transform.position == finishTransform.position)
        {
            _isActive = false;
        }
    }
}
