using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    void Awake()
    {
        instance = this;
    }
    
    public void NewGame()
    {
        PlayerPrefs.SetString("Nivel","Level1");
        Continue();
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("Nivel"));
    }

    public void NextLevel(string LevelName)
    {
        PlayerPrefs.SetString("Nivel",LevelName);
        Continue();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
