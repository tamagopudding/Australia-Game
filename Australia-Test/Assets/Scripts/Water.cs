using System.Security;
using UnityEngine;

public class Water : MonoBehaviour
{
    PlayerMovement movement;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.GetComponentInParent<PlayerMovement>() != null)
        {
            movement = other.GetComponentInParent<PlayerMovement>();
            movement.isSwimming = true;
            movement.ResetVelocity();
        }
        if (other.CompareTag("EyeLevel"))
        {
            other.GetComponentInParent<Rigidbody>().useGravity = false;
            if(movement != null)
            {
                movement.ResetVelocity();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponentInParent<PlayerMovement>() != null)
        {
            PlayerMovement movement = other.GetComponentInParent<PlayerMovement>();
            movement.isSwimming = false;
            movement.ResetVelocity();
        }
    }
}
