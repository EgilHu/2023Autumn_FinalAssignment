using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2.0f; // ���������
    public float minYRotation = -60.0f; // ��СY����ת�Ƕ�
    public float maxYRotation = 60.0f; // ���Y����ת�Ƕ�


    private float rotationX = 0;

    void Update()
    {
        // ��ȡ�������
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // ���������������������ת
        transform.Rotate(Vector3.up * mouseX * sensitivity);

        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, minYRotation, maxYRotation);

        // Ӧ����ת
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
