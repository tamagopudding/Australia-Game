using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator objectToAnimate;
    public string openBooleanName;
    public bool isLocked;
    public float interactiveDistance = 2;

    public bool hasBeenInteractedWith;
    [SerializeField] private AudioSource dooropenAudioSource = null;
    [SerializeField] private float openDelay = 0;

    private void OnTriggerEnter(Collider other)
    {
        //Plays the door opening animation when door is locked, and distance to OBJECT is less than interactive distance
        if (isLocked == false && Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            objectToAnimate.SetBool(openBooleanName, true);
            hasBeenInteractedWith = true;
            dooropenAudioSource.PlayDelayed(openDelay);
        }
    }

    private void OnMouseOver()
    {
        //Changes the hover icon if object cna be interacted with
        if (isLocked == false && hasBeenInteractedWith == false && Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            //Interactive.overObject = true;
        }
    }
}