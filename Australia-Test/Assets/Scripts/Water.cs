using System.Security;
using UnityEngine;

public class Water : MonoBehaviour
{
    PlayerMovement movement;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.GetComponent<PlayerMovement>() != null)
        {
            movement = other.GetComponent<PlayerMovement>();
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
        if (other.CompareTag("Player") && other.GetComponent<PlayerMovement>() != null)
        {
            PlayerMovement movement = other.GetComponent<PlayerMovement>();
            movement.isSwimming = false;
            movement.ResetVelocity();
        }
    }
}
