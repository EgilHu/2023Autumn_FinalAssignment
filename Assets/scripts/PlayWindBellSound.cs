using UnityEngine;
using System.Collections;

public class PlayWindBellSound : MonoBehaviour
{
    public AudioClip firstSound; 
    public AudioClip secondSound; 

    private AudioSource audioSource;
    private Transform playerTransform;
    private float maxDistance = 100f;  // 设置最大距离

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayFirstSound();

            // 启动协程，在两秒后播放第二个音效
            StartCoroutine(PlaySecondSoundAfterDelay(1f));
        }
    }

    void PlayFirstSound()
    {
        // 检查AudioSource是否存在且第一个音效文件不为空
        if (audioSource != null && firstSound != null)
        {
            // 设置第一个音效文件并播放
            audioSource.clip = firstSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource或第一个音效文件未设置！");
        }
    }

    IEnumerator PlaySecondSoundAfterDelay(float delay)
    {
        // 等待指定的延迟时间
        yield return new WaitForSeconds(delay);

        // 获取距离玩家最近的"wall"物体
        Transform nearestWall = FindNearestWall();

        if (nearestWall != null)
        {
            float distanceToWall = Vector3.Distance(playerTransform.position, nearestWall.position);
            Debug.Log("Distance to Wall: " + distanceToWall);

            // 映射
            float normalizedDistance = Mathf.Clamp01(1-distanceToWall / maxDistance);

            // 设置音效文件和音量
            audioSource.clip = secondSound;
            audioSource.volume = normalizedDistance;  // 设置音量
            Debug.Log("Normalized Distance: " + normalizedDistance);  // 添加这一行检查

            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("没有找到标记为“wall”的物体！");
        }
    }

    Transform FindNearestWall()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");

        Transform nearestWall = null;
        float minDistance = float.MaxValue;

        foreach (GameObject wall in walls)
        {
            float distance = Vector3.Distance(playerTransform.position, wall.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestWall = wall.transform;
            }
        }

        return nearestWall;
    }


}