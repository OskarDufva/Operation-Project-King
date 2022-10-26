using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameManager gameManager;
    public static int EnemiesAlive = 0;
    public float TimeBetweenWaves = 5f;
    public float Countdown;
    private int waveIndex = 0;
    public WaveList[] _waveList;
    public EnemyData _enemyData;
    


    void Start()
    {

    }

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if(waveIndex == _waveList.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if(Countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            Countdown = TimeBetweenWaves;
            return;
        }

        Countdown -= Time.deltaTime;

    }

    IEnumerator SpawnWave()
    {
        WaveList wave = _waveList[waveIndex];
        EnemyData enemy = _enemyData;

        EnemiesAlive = enemy.AmountOfEnemies;

        for (int i = 0; i < enemy.AmountOfEnemies; i++)
        {
            SpawnEnemy(enemy.AmountOfEnemies);
            yield return new WaitForSeconds(1f/wave.rate);
        }

    }
    private void SpawnEnemy(int waveCount)
    {
        WaveSpawn(_waveList[waveCount]);
    }

    public void WaveSpawn(WaveList EnemyData)
    {
        for (int i = 0; i < EnemyData.Enemies.Length; i++)
        {
            Debug.Log(EnemyData.Enemies[i]);
        }
    }


}