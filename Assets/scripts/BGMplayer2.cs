using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMplayer2 : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hasBeenDestroyed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (hasBeenDestroyed && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        // 检查是否存在物体
        GameObject aaaObject = GameObject.Find("hidden door (3)");

        if (aaaObject != null && !hasBeenDestroyed)
        {
            
        }
        else
        {
            hasBeenDestroyed = true;
        }
    }
}