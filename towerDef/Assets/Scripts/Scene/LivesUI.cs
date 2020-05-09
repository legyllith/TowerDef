using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public Text LivesText;
    
   
    // Update is called once per frame
    void Update()
    {
        LivesText.text = PlayerStats.lives + " LIVES";
    }
}
