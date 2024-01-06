using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text[] textList; // ��Ŷ��text������
    public float[] displayTimes; // ���ÿ��text��ʾ��ʱ��
    private int currentIndex = 0; // ��ǰ��ʾ��text����

    void Start()
    {
        // ��ʼʱ��������text
        foreach (Text text in textList)
        {
            text.gameObject.SetActive(false);
        }

        // ����Э�̣���˳����ʾtext
        StartCoroutine(ShowTextSequentially());
    }

    IEnumerator ShowTextSequentially()
    {
        while (currentIndex < textList.Length)
        {
            // ��ʾ��ǰtext
            textList[currentIndex].gameObject.SetActive(true);

            // ��ȡ��ǰtext��ʾ��ʱ��
            float displayTime = (currentIndex < displayTimes.Length) ? displayTimes[currentIndex] : 5f;

            // �ȴ�ָ����ʱ��
            yield return new WaitForSeconds(displayTime);

            // ���ص�ǰtext
            textList[currentIndex].gameObject.SetActive(false);

            // ����������׼����ʾ��һ��text
            currentIndex++;
        }
    }
}
