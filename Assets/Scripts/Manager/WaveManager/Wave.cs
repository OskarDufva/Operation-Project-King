using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameManager gameManager;
    public static int EnemiesAlive = 0;
    public WaveList[] _waveList;
    


    void Start()
    {

    }

    public void SpawnWave(int waveCount)
    {
        var x = WaveSpawn(_waveList[waveCount]);
        StartCoroutine(x);
    }

    IEnumerator WaveSpawn(WaveList EnemyData)
    {
        for (int i = 0; i < EnemyData.Enemies.Length; i++)
        {
            for (int g = 0; g < EnemyData.Enemies[i].AmountOfEnemies; g++)
            {
                yield return new WaitForSeconds(EnemyData.Enemies[i].SpawnDelay);
                Instantiate(EnemyData.Enemies[i].Enemy, SpawnPoint.transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(EnemyData.Enemies[i].BreakTime);
            
        }
    }
}