using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTextAndEndGame : MonoBehaviour
{
    public Text text;
    private bool isTextVisible; // ������־��ʾ�ı��Ƿ�Ӧ����ʾ

    void Start()
    {
        if (text != null)
        {
            text.gameObject.SetActive(false);
        }

        isTextVisible = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ��ʾ�ı�
            isTextVisible = true;
            if (text != null)
            {
                text.gameObject.SetActive(true);
            }
        }
    }
}
