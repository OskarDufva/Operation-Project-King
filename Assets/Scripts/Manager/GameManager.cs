using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _waveTxt;
    [SerializeField] TextMeshProUGUI _speedTxt;

    private Wave _waveManager;
    private int ArrayCurrentLevel = -1;
    private int CurrentLevel = 0;
    private int _gameSpeed = 1;

    public static bool GameIsPaused;

    //At start of the game find the wave manager and sets the text of the waves in the hud.
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

    public void SpeedChangeBtn()
    {
        if (_gameSpeed == 1)
        {
            _gameSpeed = 2;
            _speedTxt.text = 2 + "X >>";
            ChangeSpeed();
        }
        else if (_gameSpeed == 2)
        {
            _gameSpeed = 4;
            _speedTxt.text = 4 + "X >>";
            ChangeSpeed();

        }
        else if (_gameSpeed == 4)
        {
            _gameSpeed = 1;
            _speedTxt.text = 1 + "X >>";
            ChangeSpeed();
        }
    }
    private void ChangeSpeed()
    {
        Time.timeScale = _gameSpeed;
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
