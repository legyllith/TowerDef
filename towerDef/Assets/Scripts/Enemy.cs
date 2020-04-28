
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector] public float speed;
    public float health = 100f;

    public int worth = 50; //valeur d or gagnez a la mort.

    public GameObject deathEffect;

    public void Start()
    {
        speed = startSpeed;
    }


    public void takeDammage(float amout)
    {
        health -= amout;
        if(health <= 0)
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
        PlayerStats.money += worth;

        GameObject deathParticule = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathParticule, 2f);
        Destroy(gameObject);
    }
}
