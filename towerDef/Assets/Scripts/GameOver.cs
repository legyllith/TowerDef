using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roudsText;
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    void OnEnable()//lis quand l objet se fait enable
    {
        roudsText.text = PlayerStats.rounds.ToString();
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
