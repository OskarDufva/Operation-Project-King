using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text _waveTxt;
    private Wave _waveManager;
    private int CurrentLevel = -1;

    private void Start()
    {
        _waveManager = FindObjectOfType<Wave>();
        int tempInt = CurrentLevel + 1;
        _waveTxt.text = $"Wave {tempInt.ToString()}/{_waveManager.WaveAmountCounter()}";
    }

    public void NextWave()
    {
        if(_waveManager.EnemiesAlive == 0)
        {
            CurrentLevel++;
            int tempInt = CurrentLevel + 1;
            //_waveTxt.text = "Wave " + CurrentLevel.ToString() + "/" + _waveManager.WaveAmountCounter();
            _waveTxt.text = $"Wave {tempInt.ToString()}/{_waveManager.WaveAmountCounter()}";

            print(CurrentLevel);
            _waveManager.SpawnWave(CurrentLevel);
        }
        else
        {
            print("Cant spawn next wave enemies not 0");
        }
    }

    public void WinLevel()
    {

    }
}
