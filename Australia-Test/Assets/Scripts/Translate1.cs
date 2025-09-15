using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Translate1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public float speedpleasework = 1;
    // public float smoothTime = 0.5f;
    //public GameObject Trigger1;
    //public GameObject Destination1;
    //public float speed;
     //public Vector3 target = new Vector3(8, -2, 18);
    //Vector3 currentVelocity;
    // public float moveDuration = 5;
   
    public Transform Trigger1;
    public Transform Destination1;
    public float distance = 1;

    [Range(0, 1)] public float lerpSpeed;

    public float moveValue;
    public bool moveTarget = false;

    private void Start()
    {
        //Trigger1.transform.position = Vector3.MoveTowards(Trigger1.transform.position, Destination1.transform.position, speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Trigger1.transform.position = Vector3.MoveTowards(Trigger1.transform.position, Destination1.transform.position, speed);
        //Trigger1.transform.position = Vector3.MoveTowards(transform.position, target, speedpleasework * Time.deltaTime);
        //Trigger1.transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
        moveTarget = true;  


    }

    // Update is called once per frame
    private void Update()
    {
        if (moveTarget)
        {
            Trigger1.position = Vector3.Lerp(Trigger1.position, Destination1.position, Time.deltaTime * lerpSpeed);
        }
        //Trigger1.transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    
}
