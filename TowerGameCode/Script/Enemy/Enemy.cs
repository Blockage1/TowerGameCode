using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxHeealth = 5;

    float currentHealth; 

    public float speed = 10f;

    Transform target;
    int wavePointIndex = 0;

     public int costOfenemy;

    public int hitCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
    }
    void Start()
    {

        currentHealth = maxHeealth;
        target = WayPoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World); // wht normizl the same length the same fixed speed ,,so the only thing that controlling the speed will be out speed variable


        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hitCount++;
           
        }
    }
    private void GetNextWayPoint()
    {
        if (wavePointIndex >= WayPoints.points.Length - 1)
        {
            Debug.Log("Home");

                BuildManger.instance.wayPointvalue--;
            if (BuildManger.instance.wayPointvalue > 0)
            {
                BuildManger.instance.health[BuildManger.instance.wayPointvalue].enabled = false;

            }
            else if (BuildManger.instance.wayPointvalue <= 0)
            {
                SceneManager.LoadScene(2);
            }


            Destroy(gameObject);
            return;
        }
        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];



    }
}
