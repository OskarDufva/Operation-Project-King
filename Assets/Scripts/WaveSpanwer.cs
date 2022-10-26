using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpanwer : MonoBehaviour
{
    [SerializeField] WaveList[] _waveList;

    private void Start()
    {
        SpawnWave(0);    
    }

    private void SpawnWave(int waveCount)
    {
        WaveSpawn(_waveList[waveCount]);
    }

    public void WaveSpawn(WaveList enemyList)
    {
        for (int i = 0; i < enemyList.Enemies.Length; i++)
        {
            Debug.Log(enemyList.Enemies[i]);
        }
    }
}
