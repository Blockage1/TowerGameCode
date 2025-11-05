using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab ,redEnemyPerfab;

    public float timeBetweenWaves = 5f;

    public float countDown = 2f;

    public TextMeshProUGUI waveCountDownText;

    public int waveIndex = 1;

    public int waveCount = 1,maxWaveCount = 10;

    public Transform spawnPoint;

    public TextMeshProUGUI text;

    public bool isPaused = false;

    public ParticleSystem winner;

    void Update()
    {

        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;

        }
        countDown -= Time.deltaTime;


        waveCountDownText.text = Mathf.Round(countDown).ToString();


    }

    
    IEnumerator SpawnWave()
    {

        if (waveCount >= maxWaveCount)
        {
            winner.Play();
            Invoke("Late", 4f);
            yield break;
            
        }



        int randomSpawn = UnityEngine.Random.Range(1,6);
        if ( waveCount <= maxWaveCount &&waveIndex < 11 )
        {
            for (int i = 0; i < randomSpawn; i++)
            {
                SpawnEnenmy();
                text.text = waveCount.ToString();

                yield return new WaitForSeconds(0.5f);
            }
            waveIndex++;
            randomSpawn = UnityEngine.Random.Range(1, 6);

            if (waveIndex >= 10)
            {
                waveCount++;
                waveIndex = 0;
 
            }
            Debug.Log("WaveIncoming");
        }
     
    }
    public void Late()
    {
        SceneManager.LoadScene(3);

    }

    private void SpawnEnenmy()
    {
        int randomEnemy = UnityEngine.Random.Range(0, 2); 

        if (randomEnemy == 0)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Instantiate(redEnemyPerfab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
