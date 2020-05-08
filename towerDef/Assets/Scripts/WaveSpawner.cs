
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float timeBetweenWaves = 5f;

    [SerializeField]
    private Text  waveCountdownTimer;

    private float countdown = 5f; // temps avant le début des vagues

    private int waveIndex = 0;

    public GameManager gameManager;

    

    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }
        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave()); //cette fonction est la methode d appeller une fonction de coroutine
            countdown = timeBetweenWaves; //remet le compteur avant la prochaine vague
            return;
        }

        countdown -= Time.deltaTime; // retire petit a petit du temps
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownTimer.text= string.Format("{0:00.00}",countdown);
    }

    IEnumerator SpawnWave()// fait apparraitre des vague
    {
        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }

        waveIndex++;
        

    }

    void SpawnEnemy(GameObject enemy)// fait apparaitre 1 enemy
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
