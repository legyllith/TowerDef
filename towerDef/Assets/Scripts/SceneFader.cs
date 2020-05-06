using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;

    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    //Fade In ecrant noir vers scenes
    IEnumerator FadeIn()
    {
        float t = 1f;//1= opaque et 0 = transparent
        while (t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f,0f,0f,a);// changer une couleur dans unity demande de totu changer et pas juste l alpha
            yield return 0;
        }
    }

    //Fade out scenes vers ecran noir POUR CHANGER DE SCENE
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;//1= opaque et 0 = transparent
        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);// changer une couleur dans unity demande de totu changer et pas juste l alpha
            yield return 0;
        }
        //le code ne se lira que quand le fondu sera terminé
        SceneManager.LoadScene(scene);

    }

}
