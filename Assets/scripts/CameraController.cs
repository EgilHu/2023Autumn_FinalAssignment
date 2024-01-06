using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2.0f; // 鼠标灵敏度
    public float minYRotation = -60.0f; // 最小Y轴旋转角度
    public float maxYRotation = 60.0f; // 最大Y轴旋转角度


    private float rotationX = 0;

    void Update()
    {
        // 获取鼠标输入
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 根据鼠标输入调整相机的旋转
        transform.Rotate(Vector3.up * mouseX * sensitivity);

        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, minYRotation, maxYRotation);

        // 应用旋转
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
