using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    public GameObject pauseScreen;
    public GameObject gameUI;
    public GameObject exitScreen;
    public GameObject winScreen;
    
    private int score;
    public int maxScore = 0;
    public string nextLevel;
    
    public TextMeshProUGUI txtScore;
    public AudioClip clickSound;
    public AudioClip bgMusic;

    public GameObject player;
    public GameObject playerPointer;
    public GameObject exit;
    public GameObject exitPointer;

    void Awake()
    {
        instance = this;
        score = 0;
        Time.timeScale = 1;
    }

    void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        SoundManager.instance.PlaySound(bgMusic, transform, 1f, true);
    }

    public void PlayMenuClick()
    {
        SoundManager.instance.PlaySound(clickSound, transform, 1f, false);
    }

    public void AddScore()
    {
        score++;
        txtScore.text = score + "/" + maxScore;
        if (score == maxScore) 
        {
            exit.SetActive(true);
            exitPointer.SetActive(true);
        }
    }

    public void GameStart()
    {
        pauseScreen.SetActive(false);
        gameUI.SetActive(true);
        playerPointer.SetActive(true);
        if (score == 3) 
        {
            exitPointer.SetActive(true);
        }
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().isKinematic = false;
        Time.timeScale = 1;
        
        PlayMenuClick();
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        gameUI.SetActive(false);
        playerPointer.SetActive(false);
        exitPointer.SetActive(false);
        //player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Time.timeScale = 0;

        PlayMenuClick();
    }

    public void ExitGame()
    {
        exitScreen.SetActive(true);
        pauseScreen.SetActive(false);

        PlayMenuClick();
    }

    public void CancelExit()
    {
        exitScreen.SetActive(false);
        pauseScreen.SetActive(true);

        PlayMenuClick();
    }

    public void ConfirmExit()
    {
        LevelLoader.instance.ReturnMenu();
        
        PlayMenuClick();
    }

    public void GameWon()
    {
        gameUI.SetActive(false);
        winScreen.SetActive(true);
        playerPointer.SetActive(false);
        exitPointer.SetActive(false);
        Time.timeScale = 0;
    }

    public void LoadNextLevel()
    {
        PlayMenuClick();
        LevelLoader.instance.NextLevel(nextLevel);
    }
}
