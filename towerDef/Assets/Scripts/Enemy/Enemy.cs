using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector] public float speed;
    public float starthealth = 100f;
    private float health;

    public int worth = 50; //valeur d or gagnez a la mort.

    public GameObject deathEffect;

    public GameObject life;
    public Image HealthBar;

    private bool isDead = false;

    public void Start()
    {
        health = starthealth;
        speed = startSpeed;
    }


    public void takeDammage(float amout)
    {
        health -= amout;
        if (!life.activeSelf)
        {
            life.SetActive(true);
        }
        HealthBar.fillAmount = health/starthealth;
        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }

    private void Die()
    {
        isDead = true;
        PlayerStats.money += worth;

        GameObject deathParticule = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathParticule, 2f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}
