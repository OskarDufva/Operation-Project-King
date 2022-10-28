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


    public static bool GameIsPaused;

    private void Start()
    {
        _waveManager = FindObjectOfType<Wave>();
        _waveTxt.text = $"Wave {CurrentLevel.ToString()}/{_waveManager.WaveAmountCounter()}";
    }

    void Update()
    {
        // when space is pressed pause the game, if you press space again resume to normalspeed. 
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameIsPaused = !GameIsPaused;
            PauseGame();
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            NormalGameSpeed();
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SpeedUpGame();
        }
    }

    // if game is paused time scale equals 0 and if game isnt paused time scale equals normal speed. 
    void PauseGame()
    {
        if (GameIsPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }

    void NormalGameSpeed()
    {
        Time.timeScale = 1;
    }

    void SpeedUpGame()
    {
        Time.timeScale = 2;
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
