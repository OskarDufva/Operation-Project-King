using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class TempDeathScript : MonoBehaviour
{
    private float timer;
    private Wave _waveManager;

    private void Start()
    {
        _waveManager = FindObjectOfType<Wave>();
    }
    public void Update()
    {

        if (timer > 5)
        {
            _waveManager.EnemyDeath();
            Destroy(gameObject);
            // timer done

            // reset it if you want to:

            timer = 0;

        }



        timer += Time.deltaTime;

    }
}
