using UnityEngine;

public class SoundControler : MonoBehaviour
{
    AudioSource source;
    Collider soundTrigger;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        source.Play();
    }
}
