using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    public string nextLevel = "Scenes/scene2";
    public int LevelToUnlock = 2;

    public void OnEnable()
    {
        if (LevelToUnlock > PlayerPrefs.GetInt("levelReachedTD", 1))
        {
            PlayerPrefs.SetInt("levelReachedTD", LevelToUnlock);
        }
    }

    public void Continue()
    {
        
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}