using UnityEngine;

public class PlayWindBellSound : MonoBehaviour
{
    public AudioClip yourSound;  // ��Inspector������ָ�������Ч�ļ�

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
        // ���AudioSource�Ƿ��������Ч�ļ���Ϊ��
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource����Ч�ļ�δ���ã�");
        }
    }
}
