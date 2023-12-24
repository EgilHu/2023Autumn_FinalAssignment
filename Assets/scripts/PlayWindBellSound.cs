using UnityEngine;
using System.Collections;

public class PlayWindBellSound : MonoBehaviour
{
    public AudioClip firstSound; 
    public AudioClip secondSound; 

    private AudioSource audioSource;
    private Transform playerTransform;
    private float maxDistance = 100f;  // ����������

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

            // ����Э�̣�������󲥷ŵڶ�����Ч
            StartCoroutine(PlaySecondSoundAfterDelay(1f));
        }
    }

    void PlayFirstSound()
    {
        // ���AudioSource�Ƿ�����ҵ�һ����Ч�ļ���Ϊ��
        if (audioSource != null && firstSound != null)
        {
            // ���õ�һ����Ч�ļ�������
            audioSource.clip = firstSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource���һ����Ч�ļ�δ���ã�");
        }
    }

    IEnumerator PlaySecondSoundAfterDelay(float delay)
    {
        // �ȴ�ָ�����ӳ�ʱ��
        yield return new WaitForSeconds(delay);

        // ��ȡ������������"wall"����
        Transform nearestWall = FindNearestWall();

        if (nearestWall != null)
        {
            float distanceToWall = Vector3.Distance(playerTransform.position, nearestWall.position);
            Debug.Log("Distance to Wall: " + distanceToWall);

            // ӳ��
            float normalizedDistance = Mathf.Clamp01(1-distanceToWall / maxDistance);

            // ������Ч�ļ�������
            audioSource.clip = secondSound;
            audioSource.volume = normalizedDistance;  // ��������
            Debug.Log("Normalized Distance: " + normalizedDistance);  // �����һ�м��

            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("û���ҵ����Ϊ��wall�������壡");
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