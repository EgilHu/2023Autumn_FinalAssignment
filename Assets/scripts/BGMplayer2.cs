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

        // 检查是否存在物体
        GameObject aaaObject = GameObject.Find("hidden door (3)");

        if (aaaObject != null && !hasBeenDestroyed)
        {
            // 当物体存在时执行的操作
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
        Debug.Log("游戏结束");
        Application.Quit();
    }
}
