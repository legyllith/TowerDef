using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader sceneFader;
    public Button[] levelButton;

    public void Start()
    {
        /*PlayerPrefs.DeleteKey("levelReachedTD");*/
        int levelReachedTD = PlayerPrefs.GetInt("levelReachedTD", 1);
        Debug.Log(levelReachedTD);
        for (int i=0; i< levelButton.Length; i++)
        {
            if( i+1 > levelReachedTD)
            {
                levelButton[i].interactable = false;
            }
        }
    }

    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }

}
