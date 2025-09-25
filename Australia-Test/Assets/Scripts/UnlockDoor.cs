using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public DoorController doorToUnlock;
    public bool turnOffObject;

    bool hasBeenInteractedWith;
    [SerializeField] private AudioSource KeyJinggleaudioSource = null;
    [SerializeField] private float openDelay = 0;

    private void OnTriggerEnter(Collider other)
    {
        //sets the door to be interactable
        doorToUnlock.isLocked = false;
        hasBeenInteractedWith = true;
        //turn off this object?
        if (turnOffObject)
        {
            this.gameObject.SetActive(false);
            KeyJinggleaudioSource.PlayDelayed(openDelay);
        }
    }

    private void OnMouseOver()
    {
        //interact with this object
        if (hasBeenInteractedWith == false)
        {
           // Interactive.overObject = true;
        }
    }
}
