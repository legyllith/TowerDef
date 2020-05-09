using UnityEngine;

[RequireComponent(typeof(Enemy))]//besoin du componant Enemy movement pour fonctionné
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>(); //on recupère le script ennemy qu iest forcement liée a uEnemy Movement
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position; //permet de creer le vecteur vers lequ'elle il doit aller
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        //applique le déplacement, le normalize * speed permet d aller a la vitesse spped et * time.deltatime dans le temps

        float error = Mathf.Min(0.5f, 0.1f + 0.05f * enemy.speed);

        if (Vector3.Distance(transform.position, target.position) <= error)// permet de prendre une compte les erreur de déplacement liée a unité
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWaypoint() // fonction passant au prochain waypoint
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
