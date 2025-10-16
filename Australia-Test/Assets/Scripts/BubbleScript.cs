using UnityEngine;


public class BubbleScript : MonoBehaviour
{
    public ParticleSystem bubble;
    public GameObject bubbleTrigger;
    //Collider underwaterSound;

    private void Awake()
    {
        //source = GetComponent<AudioSource>();
        //soundTrigger = GetComponent<Collider>();
        //underwaterSound = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
       bubble.Play();
        // if (collision.gameObject.tag == "Object")
        //{
       //     bubbleTrigger.SetActive(true);
        //}
        //source.Play();
        //waterSource.Play(); 
        //gameObject.SetActive(false);
    }
}
