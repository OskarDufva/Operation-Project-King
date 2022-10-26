using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct WaveList
{
    public string WaveName;
    public EnemyData[] Enemies;
}

[System.Serializable]
public struct EnemyData
{
    public GameObject Enemy;
    public int AmountOfEnemies;
    public float SpawnDelay; 
}
[System.Serializable]
public struct RandomSpawn
{
    public float minSpawn;
    public float maxSpawn;
}
