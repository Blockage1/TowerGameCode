using System;
using UnityEngine;

public class Turret : MonoBehaviour
{

     Transform target;

    public float range = 15f;

    public float turnSpeed = 10f;

    public string enemyTag = "Enemy";

    public Transform partToRotate;

    public GameObject bulletPerfab;
    public Transform firePoint;

    public float fireRate =1f;

    float fireCountDown = 0f;  
    public GameObject[] bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
       // SpawnBullets(10);

    }
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        
        Vector3 dir = target.position - transform.position; // targert lockin
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        if (fireCountDown <=0)
        {
            Shoot();
            fireCountDown = 1f/fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void SpawnBullets(int mag)
    {
        bullet = new GameObject[mag];

        for (int i = 0; i < mag; i++)
        {
            GameObject ammo = Instantiate(bulletPerfab);
            ammo.SetActive(false);
            bullet[i] = ammo;

        }
    }
    private void Shoot()
    {

        GameObject bulletGo = (GameObject)Instantiate(bulletPerfab,firePoint.position,firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null &&  shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
