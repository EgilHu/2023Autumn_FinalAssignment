using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTextAndEndGame : MonoBehaviour
{
    public Text text;
    private bool isTextVisible; // 新增标志表示文本是否应该显示

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
            // 显示文本
            isTextVisible = true;
            if (text != null)
            {
                text.gameObject.SetActive(true);
            }
        }
    }
}
