using UnityEngine;

public class SoundControler : MonoBehaviour
{
    AudioSource source;
    AudioSource waterSource;
    Collider soundTrigger;
    Collider underwaterSound;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider>();
        underwaterSound = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        source.Play();
        waterSource.Play(); 
    }
}
