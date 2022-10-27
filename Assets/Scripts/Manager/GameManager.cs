using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Wave _waveManager;

    private int CurrentLevel = -1;

    private void Start()
    {
        _waveManager = FindObjectOfType<Wave>();
    }

    public void NextWave()
    {
        CurrentLevel++;
        print(CurrentLevel);
        _waveManager.SpawnWave(CurrentLevel);
    }

    public void WinLevel()
    {

    }
}
