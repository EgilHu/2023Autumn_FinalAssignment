using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip audioClip1; // ��Ƶ1
    public AudioClip audioClip2; // ��Ƶ2

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // ������Ƶ1
        if (audioClip1 != null)
        {
            audioSource.clip = audioClip1;
            audioSource.Play();
        }
    }

    void Update()
    {
        GameObject hiddenDoor3 = GameObject.Find("hidden door (3)");
        if (hiddenDoor3 == null && audioClip2 != null)
        {
            audioSource.Stop();
            audioSource.clip = audioClip2;
            audioSource.Play();
            Debug.Log(0);
        }
    }
}
