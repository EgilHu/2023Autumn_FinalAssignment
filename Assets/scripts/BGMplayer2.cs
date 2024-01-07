using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMplayer2 : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hasBeenDestroyed = false;
    private bool gameEnded = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (hasBeenDestroyed && !audioSource.isPlaying && !gameEnded)
        {
            audioSource.Play();
            StartCoroutine(WaitForBGMEnd());
        }

        // ����Ƿ��������
        GameObject aaaObject = GameObject.Find("hidden door (3)");

        if (aaaObject != null && !hasBeenDestroyed)
        {
            // ���������ʱִ�еĲ���
        }
        else
        {
            hasBeenDestroyed = true;
        }
    }

    IEnumerator WaitForBGMEnd()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        EndGame();
    }

    void EndGame()
    {
        Debug.Log("��Ϸ����");
        Application.Quit();
    }
}
