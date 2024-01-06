using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public float pickupRange = 10f;
    public LayerMask pickupLayer;
    public Text myText;

    private GameObject pickedObject; // 保存被捡起的物体

    private void Start()
    {
        myText.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && pickedObject != null)
        {
            Destroy(pickedObject);
            pickedObject = null;
            myText.enabled = false; // 隐藏Text
        }
        else
        {
            TryPickup();
        }
    }

    void TryPickup()
    {
        // 获取场景中所有符合图层条件的物体
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRange, pickupLayer);

        // 遍历检测到的物体
        foreach (Collider collider in colliders)
        {
            // 检测到可捡起的物体
            pickedObject = collider.gameObject;

            // 显示Text
            myText.enabled = true;
        }
    }
}
