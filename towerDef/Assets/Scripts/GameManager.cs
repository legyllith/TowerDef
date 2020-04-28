using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    public GameObject gameOverUI;

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
}
