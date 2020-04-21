
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]//voir dans l editeur
    private Transform enemyPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float timeBetweenWaves = 5f;

    [SerializeField]
    private Text  waveCountdownTimer;

    private float countdown = 5f; // temps avant le début des vagues

    private int waveIndex = 0;

    

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave()); //cette fonction est la methode d appeller une fonction de coroutine
            countdown = timeBetweenWaves; //remet le compteur avant la prochaine vague
        }

        countdown -= Time.deltaTime; // retire petit a petit du temps
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownTimer.text= string.Format("{0:00.00}",countdown);
    }

    IEnumerator SpawnWave()// fait apparraitre des vague
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy()// fait apparaitre 1 enemy
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
