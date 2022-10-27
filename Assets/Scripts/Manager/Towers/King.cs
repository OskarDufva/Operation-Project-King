using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : MonoBehaviour
{
    public float healthAmount = 100;
    public Image healthBar;

    private void Update()
    {
        if (healthAmount <= 0)
        {

        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        //healthBar = fillAmount = healthAmount / 100;
    }
}
