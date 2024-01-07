using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShakeBellText : MonoBehaviour
{
    public GameObject objectA;  
    public Text[] textList; // ��Ŷ��text������
    public float[] displayTimes; // ���ÿ��text��ʾ��ʱ��
    private int currentIndex = 0; // ��ǰ��ʾ��text����

    private void Start()
    {
        foreach (Text text in textList)
        {
            text.gameObject.SetActive(false);
        }

        StartCoroutine(CheckObjectDestroy());
    }

    IEnumerator CheckObjectDestroy()
    {
        while (true)  // ����ѭ��
        {
            // �ȴ�10��
            yield return new WaitForSeconds(10f);

            if (objectA == null && currentIndex < textList.Length)
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
            else
            {
                yield return null;  // �������Aδ�����ٻ��Ѿ���ʾ����text���ȴ���һ�μ��
            }
        }
    }
}
