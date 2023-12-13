using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemyHealthManager : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public healthBar healthbar;
    public TMP_Text healthText;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeHeadDamage(int damage)
    {
        TakeDamage(damage);
        UpdateHealthText();
    }

    public void TakeBodyDamage()
    {
        TakeDamage(1);
        UpdateHealthText();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
        currentHealth = Mathf.Max(currentHealth, 0);
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
        else
        {
            Debug.LogError("Health Text not assigned in the inspector!");
        }
    }
}
