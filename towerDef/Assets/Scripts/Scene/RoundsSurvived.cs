using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundsSurvived : MonoBehaviour
{
    public Text roudsText;

    void OnEnable()//lis quand l objet se fait enable
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roudsText.text = "0";
        int round = 0;
        
        yield return new WaitForSeconds(0.7f);

        while (round < PlayerStats.rounds)
        {
            round++;
            roudsText.text = round.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
