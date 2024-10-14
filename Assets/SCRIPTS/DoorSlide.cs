using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DoorSlide : MonoBehaviour
{
    [SerializeField] private Transform doorTransform;
    [SerializeField] private Transform startTransform;
    [SerializeField] private Transform endTransform;
    private LinearDrive linearDrive;
    private LinearMapping linearMapping;

    private void Start()
    {
        linearDrive = GetComponentInChildren<LinearDrive>();

        //linearDrive.linearMapping.value = 1;
        Debug.Log(linearDrive);
        StartCoroutine(PausedInit());
    }

    

    private void FixedUpdate()
    {
        
        doorTransform.position = Vector3.Lerp(startTransform.position,endTransform.position, linearDrive.linearMapping.value);
    }

    IEnumerator PausedInit()
    {
        yield return new WaitForFixedUpdate();
        linearDrive.linearMapping.value = 0;
    }

}
