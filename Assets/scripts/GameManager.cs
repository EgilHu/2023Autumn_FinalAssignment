using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tombSceneObject;
    public GameObject kitchenObject;

    private bool tombSceneActivated = false;
    private bool kitchenActivated = false;
    private float tombSceneTimer = 0f;
    private float kitchenTimer = 0f;

    public AudioClip wallEchoSound;

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
        // �����ո��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ���tombScene����δ�������tombSceneActivatedΪfalse���򼤻���
            if (!tombSceneActivated)
            {
                tombSceneObject.SetActive(true);
                tombSceneActivated = true;
                tombSceneTimer = Time.time + 20f; // ����20�����ʧ
            }
            // ���tombScene�����Ѽ������20���ѹ�������������������kitchen����
            else if (Time.time >= tombSceneTimer && !kitchenActivated)
            {
                tombSceneObject.SetActive(false);
                kitchenObject.SetActive(true);
                kitchenActivated = true;
                kitchenTimer = Time.time + 2f; // ����2����ٴ���Ӧ�ո��
            }
            // ���kitchen�����Ѽ������2���ѹ��������ԭ�пո������
            else if (Time.time >= kitchenTimer)
            {
                // ����Э�̣�������󲥷ŵڶ�����Ч
                StartCoroutine(PlayWallEchoSoundAfterDelay(1f));
            }
        }

        IEnumerator PlayWallEchoSoundAfterDelay(float delay)
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
                float normalizedDistance = Mathf.Clamp01(1 - distanceToWall / maxDistance);

                // ������Ч�ļ�������
                audioSource.clip = wallEchoSound;
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
}
