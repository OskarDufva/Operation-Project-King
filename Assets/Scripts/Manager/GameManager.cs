using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text _waveTxt;
    private Wave _waveManager;
    private int ArrayCurrentLevel = -1;
    private int CurrentLevel = 0;
    private void Start()
    {
        _waveManager = FindObjectOfType<Wave>();
        _waveTxt.text = $"Wave {CurrentLevel.ToString()}/{_waveManager.WaveAmountCounter()}";
    }

    public void NextWave()
    {
        if(_waveManager.EnemiesAlive == 0 )
        {
            ArrayCurrentLevel++;
            CurrentLevel++;
            if (ArrayCurrentLevel == _waveManager.WaveAmountCounter())
            {
                WinLevel();
                return;
            }
            _waveTxt.text = $"Wave {CurrentLevel.ToString()}/{_waveManager.WaveAmountCounter()}";
            _waveManager.SpawnWave(ArrayCurrentLevel);
            print("Currentl level " + CurrentLevel);
            print("WaveAmount " + _waveManager.WaveAmountCounter());
        }
        else
        {
            print("Cant spawn next wave enemies not 0");
        }
    }

    public void WinLevel()
    {
        print("Won the game poggers");
    }
}
