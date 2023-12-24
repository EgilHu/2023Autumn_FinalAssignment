using UnityEngine;

public class PlayWindBellSound : MonoBehaviour
{
    public AudioClip yourSound;  // 在Inspector窗口中指定你的音效文件

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = yourSound;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        // 检查AudioSource是否存在且音效文件不为空
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource或音效文件未设置！");
        }
    }
}
