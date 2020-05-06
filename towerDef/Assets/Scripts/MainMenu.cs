using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad = "Scenes"+"/"+"scene1";
    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(LevelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Fermeture du jeu");
        Application.Quit();
    }
}
