using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    public int damageDealt;

    public int worth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = currentHealth;
    }

    private void Update()
    {
        if (currentHealth < 0)
        {
            Die();
            Debug.Log("EnemyDead");
        }
    }

    void Die()
    {
        //CurrencySystem.Gold += worth;
    }

}
