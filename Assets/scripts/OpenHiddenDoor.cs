using UnityEngine;

public class OpenHiddenDoor : MonoBehaviour
{
    public float interactionDistance = 2f; // ���彻������
    public float scrollWheelSensitivity = 1f; // ����������

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
                // ������
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
