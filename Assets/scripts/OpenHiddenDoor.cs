using UnityEngine;

public class OpenHiddenDoor : MonoBehaviour
{
    public float interactionDistance = 2f; // 定义交互距离
    public float scrollWheelSensitivity = 1f; // 滚轮灵敏度

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
                // 隐藏门
                nearestDoor.SetActive(false);
            }
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
