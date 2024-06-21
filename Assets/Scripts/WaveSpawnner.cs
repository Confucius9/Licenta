using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Content;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Wave
{
    public string waveName; // Numele valului
    public int noOfEnemies; // Num?rul de inamici în acest wave
    public GameObject[] typeOfEnemies; // Tipurile de inamici care apar în acest wave
    public float spawnInterval; // Intervalul de timp dintre spawn-urile inamicilor
}

public class WaveSpawnner : MonoBehaviour
{
    public Wave[] waves; // Array de valuri 
    public Transform[] spawnPoints; // Punctele de spawn pentru inamici
    public Animator animator; // Animator pentru tranzi?ii vizuale
    public Text waveName; // Text pentru afi?area numelui valului curent
    private UIManager uiManager; // Referin?? la UIManager pentru gestionarea UI-ului

    private Wave currentWave; // Valul curent
    private int currentWaveNumber; // Num?rul valului curent
    private float nextSpawnTime; // Timpul pentru urm?torul spawn

    private bool canSpawn = true; // Indicator dac? se poate face spawn
    private bool canAnimate = false; // Indicator dac? se poate anima tranzi?ia
    public GameObject win = UIManager.winScreen; // Referin?? la ecranul de victorie

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemies.Length==0)
        {
            if (currentWaveNumber + 1 != waves.Length)
            {
                if (canAnimate)
                {
                    waveName.text = waves[currentWaveNumber + 1].waveName;
                    animator.SetTrigger("WaveComplete");
                    canAnimate = false;
                }
            }
            else
            {
                win.SetActive(true);
                Debug.Log("Game Finished");
            }
        }
    }

    void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    private void SpawnWave()
    {
        if (canSpawn && nextSpawnTime<Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.noOfEnemies==0)
            {
                canSpawn = false;
                canAnimate = true;
            }
        }
    }

}
