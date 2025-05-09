using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public static PlayMusic instance;
    public AudioClip clickSound;
    public AudioClip bgMusic;
    
    void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }

    void Start()
    {
        PlayBGMusic();
    }

    public void PlayBGMusic()
    {
        SoundManager.instance.PlaySound(bgMusic, transform, 1f, true);
    }

    public void PlayMenuClick()
    {
        SoundManager.instance.PlaySound(clickSound, transform, 1f, false);
    }
}
