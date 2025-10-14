using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Video;   


public class PlayerInventory : MonoBehaviour
{
    public int NumberOfItems { get; private set; }

    public UnityEvent<PlayerInventory> OnItemCollected;
    public GameObject videoPlayer;
    public int timeToStop;
    //public AudioSource CreditsSnd;

    void Start()
    {
        videoPlayer.SetActive(false);
    }

    public void ItemCollected()
    {
        ++NumberOfItems;
        OnItemCollected.Invoke(this);
        if (NumberOfItems >= 9)
        {
            videoPlayer.SetActive(true);
            //yield return new WaitForSeconds(timeToStop);
            StartCoroutine(EndGameTimer());
        }
    }
    IEnumerator EndGameTimer()
    {
        yield return new WaitForSeconds(timeToStop);
        SceneManager.LoadScene("EndGame");
    }

}
