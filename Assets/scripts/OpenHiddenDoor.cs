using UnityEngine;
using System.Collections;

public class OpenHiddenDoor : MonoBehaviour
{
    public float interactionDistance = 2f; // 定义交互距离
    public float scrollWheelSensitivity = 1f; // 滚轮灵敏度

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
                //需要改的就是这个属性：Alpha值  
                this.GetComponent<Renderer>().material.color.a
        );
        IsTrigger = false;

    }
    private void Update()
    {
        // 获取玩家位置
        Vector3 playerPosition = Camera.main.transform.position;

        // 获取滚轮输入
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

        // 如果滚轮向前滑动
        if (scrollWheelInput > 0f)
        {
            // 检测离玩家最近的标签为"hidden door"的物体
            GameObject nearestDoor = FindNearestDoor(playerPosition, "hidden door");

            // 检查门是否存在并且距离在可交互范围内
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


            //减小Alpha值，从1-30秒逐渐淡化 ,数值越大淡化越慢 
            this.GetComponent<Renderer>().material.color.a - tempTime /2 * Time.deltaTime
            );
            Destroy(this.gameObject, 2);//2秒后消除
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
