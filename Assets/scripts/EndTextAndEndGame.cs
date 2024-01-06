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

            // 延迟5秒后调用结束游戏方法
            Invoke("EndGame", 5f);
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over!");
        // Unity提供的一种结束游戏的方法是调用Application.Quit()，但在某些平台上可能无效
    }
}
