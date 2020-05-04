using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad = "Scenes"+"/"+"scene1";

    public void Play()
    {
        Debug.Log(LevelToLoad);
        SceneManager.LoadScene(LevelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Fermeture du jeu");
        Application.Quit();
    }
}
