using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded)//termine le jeu si le jeu est fini
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
        Debug.Log("Gamee Over!");
    }
}
