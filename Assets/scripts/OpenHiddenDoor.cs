using UnityEngine;
using UnityEngine.UI;

public class OpenHiddenDoor : MonoBehaviour
{
    public float interactionDistance = 3.5f;
    public float scrollWheelSensitivity = 1f;

    private float tempTime = 0;
    private bool isTriggered;
    private GameObject nearestDoor;
    private bool isWithinInteractionDistance = false;

    public Text text;

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
        text.enabled = false;
    }

    private void Update()
    {
        Vector3 playerPosition = Camera.main.transform.position;

        nearestDoor = FindNearestDoor(playerPosition, "hidden door");

        if (Vector3.Distance(playerPosition, nearestDoor.transform.position) <= interactionDistance)
        {
            isWithinInteractionDistance = true;
            if (!isTriggered) // Only show text if not triggered by O key
            {
                text.enabled = true;
            }
        }
        else
        {
            isWithinInteractionDistance = false;
            if (!isTriggered) // Hide the text when outside interaction distance and not triggered by O key
            {
                text.enabled = false;
            }
        }

        if (Input.GetKey(KeyCode.O) && isWithinInteractionDistance)
        {
            isTriggered = true;
            Debug.Log("Hidden door triggered");
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

            // Reset tempTime for the next door interaction
            tempTime = 0;
            isTriggered = false;

            // Hide text when the hidden door is destroyed
            text.enabled = false;
            //Destroy(text.gameObject, 1);
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
