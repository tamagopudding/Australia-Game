using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTrigger : MonoBehaviour
{
    public GameObject videoPlayer;
    public int timeToStop;
    public AudioSource jumpScareSnd;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
    }

    //trigger video
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            videoPlayer.SetActive(true);
            Destroy(videoPlayer, timeToStop);
            jumpScareSnd.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
