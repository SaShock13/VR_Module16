using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TNT : MonoBehaviour
{
    private Interactable interactable;
    private SteamVR_Skeleton_Poser poser;
    public SteamVR_Skeleton_Pose hoverPose; 
    public SteamVR_Skeleton_Pose defaultPose;
    [SerializeField] SteamVR_Action_Skeleton skeletonAction;

    [SerializeField] private ParticleSystem explosionFX;
    private AudioSource audioSource;
    [SerializeField] AudioClip explode;
    [SerializeField] AudioClip activation;

    private Stickable stickableSurface;
    private Rigidbody rb;
    [SerializeField] private GameObject meshes;

    public bool isCanStick = false;
    private bool _issSticked = false;

    private float timer;
    private bool isTimerOn = false;
    [SerializeField] int timerTime = 5;
    [SerializeField] TMP_Text counter;


    private void Start()
    {
        interactable = GetComponent<Interactable>();
        poser= GetComponent<SteamVR_Skeleton_Poser>();
        timer = timerTime;
        rb= GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isTimerOn)
        {
            timer -= Time.deltaTime;
            counter.text = ((int)timer +1).ToString();
            if (timer<=0)
            {
                isTimerOn = false;
                Boom();
            }
        }    
    }

    public void ChangeHandPose()
    {
        Debug.Log("Pointed Finger");
        poser.SetBlendingBehaviourEnabled("pointedFinger", true);
        
    }

    public void SetBackHandPose()
    {
        Debug.Log("Standart Hand Pose");
        poser.SetBlendingBehaviourEnabled("pointedFinger", false);
    }

    public void OnDetach()
    {
        if (isCanStick)
        {
            Stick();
        }
        else rb.isKinematic = false;
    }

    public void OnAttach()
    {
        rb.isKinematic = false;
        _issSticked = false;
    }


    private void Stick()
    {
        transform.parent = stickableSurface.transform.parent;
        rb.isKinematic = true;
        _issSticked = true;
    }
    

    public void StartTimer()
    {
        if (_issSticked)
        {
            isTimerOn = true;
            audioSource.clip = activation;
            audioSource.Play(); 
        }
    }

    public void Boom()
    {
        counter.text = "Boom";
        Debug.Log("BOOOOOOOOOMM!!!!!!!!!!!");
        audioSource.clip = explode; 
        audioSource.Play();
        var fx = Instantiate(explosionFX,transform.position,Quaternion.identity);
        meshes.SetActive(false);
        Destroy(gameObject, 1000);
        Destroy(fx.gameObject,1000);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent<Stickable>(out stickableSurface))
        {
            isCanStick = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.TryGetComponent<Stickable>(out stickableSurface))
        {
            isCanStick = false;
        }
    }

}
