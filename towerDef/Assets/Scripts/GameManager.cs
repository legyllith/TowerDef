using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    public GameObject gameOverUI;

    public string nextLevel = "Scenes/scene2";
    public int LevelToUnlock = 2;

    public SceneFader sceneFader;

    private void Start()
    {
        gameIsOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("l"))//a retirer pour le jeu
        {
            EndGame();
        }
        if (gameIsOver)//termine le jeu si le jeu est fini
        {
            return;
        }

        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        Debug.Log("Niveau Terminé ! Bravo !");
        if(LevelToUnlock > PlayerPrefs.GetInt("levelReachedTD", 1))
        {
            Debug.Log("yes");
            PlayerPrefs.SetInt("levelReachedTD", LevelToUnlock);
            Debug.Log(PlayerPrefs.GetInt("levelReachedTD", 1));
        }
        Debug.Log(PlayerPrefs.GetInt("levelReachedTD", 1));
        sceneFader.FadeTo(nextLevel);

    }
}
