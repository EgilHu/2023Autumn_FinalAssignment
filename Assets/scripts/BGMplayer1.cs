using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMplayer1 : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop =true;
        audioSource.Play();
    }

    void Update()
    {
        GameObject aaaObject = GameObject.Find("hidden door (3)");

        // 如果物体存在且尚未销毁，则继续播放音频
        if (aaaObject != null)
        {
        }
        else
        {
            audioSource.Stop();
        }
    }
}
