using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("General")]
    public float range = 15f;
    public Transform target;
    private Enemy targetEnemy;// vas permettre de faire moins de f onctio ngetComponant en la mettant en "cache"


    [Header("Use bullets (default)")]
    public GameObject bulletPrefab;
    private float fireCountdown = 0f;
    public float fireRate = 1f;

    [Header("Uselaser")]
    public bool useLaser;
    public int damageOverTime = 30;
    public float slowAmount = 0.5f; //1=100% et 0=0%
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity setup dields")]
    public string enemyTag = "Enemy";
    public Transform firepoint;
    public Transform partToRotate;
    public float turnSpeed = 8f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);// fait une update
    }

    void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnnemy = null;

        foreach (GameObject enemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnnemy = enemy;
            }
        }

        if(nearestEnnemy != null && shortestDistance <= range)
        {
            target = nearestEnnemy.transform;
            targetEnemy = target.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            
            if (useLaser && lineRenderer.enabled)
            { 
                lineRenderer.enabled = false;
                impactEffect.Stop();
                impactLight.enabled = false;
            }
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1 / fireRate;
            }

            fireCountdown -= Time.deltaTime;

        }
       
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void Laser()
    {
        targetEnemy.takeDammage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);
        if(lineRenderer.enabled == false)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, firepoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firepoint.position - target.position;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir); //tourner l impact effect en regard vers la tourelle.
        impactEffect.transform.position = target.position + dir.normalized * 1.5f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
