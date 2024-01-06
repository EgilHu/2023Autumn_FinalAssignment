using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShakeBellText : MonoBehaviour
{
    public GameObject objectA;  // 要检测销毁的物体A
    public Text[] textList; // 存放多个text的数组
    public float[] displayTimes; // 存放每个text显示的时间
    private int currentIndex = 0; // 当前显示的text索引

    private void Start()
    {
        // 初始时隐藏所有text
        foreach (Text text in textList)
        {
            text.gameObject.SetActive(false);
        }

        StartCoroutine(CheckObjectDestroy());
    }

    IEnumerator CheckObjectDestroy()
    {
        while (true)  // 无限循环
        {
            // 检测物体A是否被销毁
            if (objectA == null && currentIndex < textList.Length)
            {
                // 显示当前text
                textList[currentIndex].gameObject.SetActive(true);

                // 获取当前text显示的时间
                float displayTime = (currentIndex < displayTimes.Length) ? displayTimes[currentIndex] : 5f;

                // 等待指定的时间
                yield return new WaitForSeconds(displayTime);

                // 隐藏当前text
                textList[currentIndex].gameObject.SetActive(false);

                // 增加索引，准备显示下一个text
                currentIndex++;
            }
            else
            {
                yield return null;  // 如果物体A未被销毁或已经显示所有text，等待下一次检测
            }
        }
    }
}
