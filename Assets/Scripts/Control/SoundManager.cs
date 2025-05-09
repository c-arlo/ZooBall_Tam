using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource sound;

    void Awake()
    {
        instance = this;
    }

    public void PlaySound(AudioClip audioClip, Transform spawn, float volume, bool loop)
    {
        AudioSource audioSource = Instantiate(sound, spawn.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        if(loop) 
        {
            audioSource.loop = true;
        }
        else 
        {
            
        }
        audioSource.Play();
        float clipLen = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLen);
    }

}
