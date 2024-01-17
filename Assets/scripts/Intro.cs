using UnityEngine;

public class Intro : MonoBehaviour
{
    void Start()
    {
        // 延迟5秒后执行DisableObject方法
        Invoke("DisableObject", 11f);
    }

    void DisableObject()
    {
        gameObject.SetActive(false); // 或者 Destroy(gameObject);
    }
}
