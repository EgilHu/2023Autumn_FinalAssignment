using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEchoOfHiddenDoor : MonoBehaviour
{
    public AudioClip doorEchoSound;

    private AudioSource audioSource;
    private Transform playerTransform;
    private float maxDistance = 50f;  // ����������

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ����Э�̣�������󲥷ŵڶ�����Ч
            StartCoroutine(PlayDoorEchoSoundAfterDelay(1f));

        }

        IEnumerator PlayDoorEchoSoundAfterDelay(float delay)
        {
            // �ȴ�ָ�����ӳ�ʱ��
            yield return new WaitForSeconds(delay);

            // ��ȡ������������"wall"����
            Transform nearestWall = FindNearestHiddenDoor();

            if (nearestWall != null)
            {
                float distanceToWall = Vector3.Distance(playerTransform.position, nearestWall.position);
                Debug.Log("Distance to Wall: " + distanceToWall);

                // ӳ��
                float normalizedDistance = Mathf.Clamp01(1 - distanceToWall / maxDistance);

                // ������Ч�ļ�������
                audioSource.clip = doorEchoSound;
                audioSource.volume = normalizedDistance;  // ��������
                Debug.Log("Normalized Distance: " + normalizedDistance);  // �����һ�м��

                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("û���ҵ����Ϊ��wall�������壡");
            }
        }

        Transform FindNearestHiddenDoor()
        {
            GameObject[] walls = GameObject.FindGameObjectsWithTag("hidden door");

            Transform nearestHiddenDoor = null;
            float minDistance = float.MaxValue;

            foreach (GameObject wall in walls)
            {
                float distance = Vector3.Distance(playerTransform.position, wall.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestHiddenDoor = wall.transform;
                }
            }

            return nearestHiddenDoor;
        }

    }
}
