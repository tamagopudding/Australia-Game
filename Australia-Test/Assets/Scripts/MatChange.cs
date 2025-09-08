using UnityEngine;

public class MatChange : MonoBehaviour
{
    [SerializeField] Renderer myObject;

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myObject.material.color = Color.red;
            //gameObject.SetActive(false);
        }
    }
}
