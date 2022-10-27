using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    //public Image healthBar;


    private void Start()
    {
        maxHealth = currentHealth;
    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Dead");
            //GameOver();   
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Enemy Enemy = collision.gameObject.GetComponent<Enemy>();
        if (Enemy != null)
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
