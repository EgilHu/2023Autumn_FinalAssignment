using UnityEngine;

public class Intro : MonoBehaviour
{
    void Start()
    {
        // �ӳ�5���ִ��DisableObject����
        Invoke("DisableObject", 11f);
    }

    void DisableObject()
    {
        gameObject.SetActive(false); // ���� Destroy(gameObject);
    }
}
