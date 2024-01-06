using UnityEngine;

public class OpenHiddenDoor : MonoBehaviour
{
    private float interactionDistance = 3.5f;
    public float scrollWheelSensitivity = 1f;

    private float tempTime;
    private bool isTriggered;
    private GameObject nearestDoor;

    private void Start()
    {
        tempTime = 0;
        GetComponent<Renderer>().material.color = new Color
        (
            GetComponent<Renderer>().material.color.r,
            GetComponent<Renderer>().material.color.g,
            GetComponent<Renderer>().material.color.b,
            GetComponent<Renderer>().material.color.a
        );
        isTriggered = false;
    }

    private void Update()
    {
        Vector3 playerPosition = Camera.main.transform.position;

        if (Input.GetKey(KeyCode.O))
        {
            nearestDoor = FindNearestDoor(playerPosition, "hidden door");

            if (nearestDoor != null && Vector3.Distance(playerPosition, nearestDoor.transform.position) <= interactionDistance)
            {
                isTriggered = true;
                Debug.Log("Hidden door triggered");
            }
        }

        if (tempTime < 1)
        {
            tempTime += Time.deltaTime;
        }

        if (isTriggered && nearestDoor != null && nearestDoor.GetComponent<Renderer>().material.color.a > 0)
        {
            nearestDoor.GetComponent<Renderer>().material.color = new Color
            (
                nearestDoor.GetComponent<Renderer>().material.color.r,
                nearestDoor.GetComponent<Renderer>().material.color.g,
                nearestDoor.GetComponent<Renderer>().material.color.b,
                nearestDoor.GetComponent<Renderer>().material.color.a - tempTime / 2 * Time.deltaTime
            );
            Destroy(nearestDoor.gameObject, 2); // Destroy the nearest door after 2 seconds
        }
    }

    private GameObject FindNearestDoor(Vector3 playerPosition, string doorTag)
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag(doorTag);
        nearestDoor = null;
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
