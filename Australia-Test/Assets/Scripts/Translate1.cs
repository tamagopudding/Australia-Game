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


    [Range(0f, 25f)] public float lerpSpeed;

    public bool moveTarget = false;

    public float currentSizeValue = 0f;
    public float maximumSizeValue = 60f;

    public string positionPropertyName = "_AreaPosition1";
    public string sizePropertyName = "_Size1";

    private void Start()
    {
        //Trigger1.transform.position = Vector3.MoveTowards(Trigger1.transform.position, Destination1.transform.position, speed);
        Shader.SetGlobalVector(positionPropertyName, transform.position);
        Shader.SetGlobalFloat(sizePropertyName, 0f);
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
            currentSizeValue = Mathf.MoveTowards(currentSizeValue, maximumSizeValue, Time.deltaTime * lerpSpeed);
            Shader.SetGlobalFloat(sizePropertyName, currentSizeValue);
            
            //Trigger1.position = Vector3.Lerp(Trigger1.position, Destination1.position, Time.deltaTime * lerpSpeed);
            //Trigger2.position = Vector3.Lerp(Trigger2.position, Destination2.position, Time.deltaTime * lerpSpeed);
        }
        //Trigger1.transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    
}
