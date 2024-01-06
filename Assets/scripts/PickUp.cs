using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public float pickupRange = 10f;
    public LayerMask pickupLayer;
    public Text myText;

    private GameObject pickedObject; // ���汻���������

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
            myText.enabled = false; // ����Text
        }
        else
        {
            TryPickup();
        }
    }

    void TryPickup()
    {
        // ��ȡ���������з���ͼ������������
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRange, pickupLayer);

        // ������⵽������
        foreach (Collider collider in colliders)
        {
            // ��⵽�ɼ��������
            pickedObject = collider.gameObject;

            // ��ʾText
            myText.enabled = true;
        }
    }
}
