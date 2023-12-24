using UnityEngine;
using System.Collections;

public class OpenHiddenDoor : MonoBehaviour
{
    public float interactionDistance = 2f; // ���彻������
    public float scrollWheelSensitivity = 1f; // ����������

    private float tempTime;
    private bool IsTrigger;

    private void Start()
    {
        tempTime = 0;
        this.GetComponent<Renderer>().material.color = new Color
        (
                this.GetComponent<Renderer>().material.color.r,
                this.GetComponent<Renderer>().material.color.g,
                this.GetComponent<Renderer>().material.color.b,
                //��Ҫ�ĵľ���������ԣ�Alphaֵ  
                this.GetComponent<Renderer>().material.color.a
        );
        IsTrigger = false;

    }
    private void Update()
    {
        // ��ȡ���λ��
        Vector3 playerPosition = Camera.main.transform.position;

        // ��ȡ��������
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

        // ���������ǰ����
        if (scrollWheelInput > 0f)
        {
            // ������������ı�ǩΪ"hidden door"������
            GameObject nearestDoor = FindNearestDoor(playerPosition, "hidden door");

            // ������Ƿ���ڲ��Ҿ����ڿɽ�����Χ��
            if (nearestDoor != null && Vector3.Distance(playerPosition, nearestDoor.transform.position) <= interactionDistance)
            {
                IsTrigger = true;
            }
            
        }
        if (tempTime < 1)
        {
            tempTime = tempTime + Time.deltaTime;
        }
        if (this.GetComponent<Renderer>().material.color.a <= 1 && IsTrigger)
        {
            this.GetComponent<Renderer>().material.color = new Color
            (
                this.GetComponent<Renderer>().material.color.r,
                this.GetComponent<Renderer>().material.color.g,
                this.GetComponent<Renderer>().material.color.b,


            //��СAlphaֵ����1-30���𽥵��� ,��ֵԽ�󵭻�Խ�� 
            this.GetComponent<Renderer>().material.color.a - tempTime /2 * Time.deltaTime
            );
            Destroy(this.gameObject, 2);//2�������
        }
        
    }

    private GameObject FindNearestDoor(Vector3 playerPosition, string doorTag)
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag(doorTag);
        GameObject nearestDoor = null;
        float nearestDistance = float.MaxValue;

        foreach (GameObject door in doors)
        {
            float distance = Vector3.Distance(playerPosition, door.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestDoor = door;
            }
        }

        return nearestDoor;
    }
}
