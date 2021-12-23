using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public void PlaySong()
    {
        Debug.Log("WAAHWUUH");
        this.GetComponent<AudioSource>().Play();
    }
}
