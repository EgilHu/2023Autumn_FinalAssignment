using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEcho : MonoBehaviour
{
    public AudioClip wallEchoSound;

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
            // 启动协程，在两秒后播放第二个音效
            StartCoroutine(PlayWallEchoSoundAfterDelay(1f));
        }

    }

    IEnumerator PlayWallEchoSoundAfterDelay(float delay)
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
            float normalizedDistance = Mathf.Clamp01(1 - distanceToWall / maxDistance);

            // 设置音效文件和音量
            audioSource.clip = wallEchoSound;
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
