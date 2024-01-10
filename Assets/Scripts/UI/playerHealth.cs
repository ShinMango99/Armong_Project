using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    public healthBar healthbar;
    public Button healthButton;
    public TextMeshProUGUI healthText; // Change to TextMeshProUGUI

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        if (healthButton != null)
        {
            healthButton.onClick.AddListener(DamageOnClick);
        }
        else
        {
            Debug.LogError("Button not assigned in the inspector!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(2);
            UpdateHealthText();
        }
    }

    void DamageOnClick()
    {
        Damage(2);
        UpdateHealthText();
    }

    public void Damage(int damage)
    {
        TakeDamage(damage);
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
