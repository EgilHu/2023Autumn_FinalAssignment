using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text[] textList; // 存放多个text的数组
    public float[] displayTimes; // 存放每个text显示的时间
    private int currentIndex = 0; // 当前显示的text索引

    void Start()
    {
        // 初始时隐藏所有text
        foreach (Text text in textList)
        {
            text.gameObject.SetActive(false);
        }

        // 启动协程，按顺序显示text
        StartCoroutine(ShowTextSequentially());
    }

    IEnumerator ShowTextSequentially()
    {
        while (currentIndex < textList.Length)
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
    }
}
