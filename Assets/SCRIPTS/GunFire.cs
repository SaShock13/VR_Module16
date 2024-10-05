using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GunFire : MonoBehaviour
{
    private Interactable interactable;
    private SteamVR_Skeleton_Poser poser;
    private Animator animator;

    [SerializeField] private Transform shotOrigin;
    [SerializeField] private Transform shotAim;
    [SerializeField] AudioSource shotSound;
    [SerializeField] GameObject hitEffect;
    private ParticleSystem shotFx;

    [SerializeField] SteamVR_Action_Boolean fireAction;
    [SerializeField] PostProcessVolume postProcessVolume;
    [SerializeField] PostProcessProfile postProcessprofile1;
    [SerializeField] PostProcessProfile postProcessprofile2;


    private void Start()
    {
        interactable = GetComponent<Interactable>();
        poser = GetComponentInChildren<SteamVR_Skeleton_Poser>();
        animator = GetComponent<Animator>();
        shotFx = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (interactable.attachedToHand!=null)
        {
            var hand = interactable.attachedToHand.handType;
            if (fireAction[hand].stateDown)
            {
                Shot();
            }
        }
    }

    private void Shot()
    {
        shotSound?.Play();
        animator.SetTrigger("Shot");
        shotFx.Play();
        if (Physics.Raycast(shotOrigin.position, shotAim.position - shotOrigin.position, out RaycastHit hit, 100f))
        {
            if (hit.transform.CompareTag("Glass"))
            {
                Debug.Log("tagged by Glass");
                hit.transform.gameObject.GetComponent<Glass>().BrokeGlass();
            }
            var bulletHit = Instantiate(hitEffect, hit.point, Quaternion.identity);
            StartCoroutine(DestroyHit(bulletHit));
            //GameObject.Destroy(bulletHit,1000f);
            Debug.Log(hit.transform.name);
            if (hit.transform.name == "HeadCollider")
            {

                StartCoroutine(nameof(DeathBloom));

            } 
        }

    }

    IEnumerator DestroyHit(GameObject obj)
    {
        yield return new WaitForSeconds(1);
        Destroy(obj);
    }

   
    IEnumerator DeathBloom()
    {
        postProcessVolume.enabled = true;
        postProcessVolume.profile = postProcessprofile2;
        yield return new WaitForSeconds(5);
        postProcessVolume.enabled = false;

    }
}
