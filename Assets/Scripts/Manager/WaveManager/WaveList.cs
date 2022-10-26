using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WaveList
{
    public string WaveName;
    public EnemyData[] Enemies;
    public float rate;
}

[System.Serializable]
public struct EnemyData
{
    public GameObject[] Enemies;
    public float SpawnDelay;
    public int AmountOfEnemies;
}

[System.Serializable]
public struct RandomSpawn
{
    public float MinSpawn;
    public float MaxSpawn;
}
