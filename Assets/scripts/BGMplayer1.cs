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

        // ��������������δ���٣������������Ƶ
        if (aaaObject != null)
        {
        }
        else
        {
            audioSource.Stop();
        }
    }
}
