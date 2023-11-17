using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    public healthBar healthbar;
    public Button damageButton;
    public Text healthText;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        if (damageButton != null)
        {
            damageButton.onClick.AddListener(TakeDamageOnClick);
        }
        else
        {
            Debug.LogError("Button not assigned in the inspector!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(2);
            UpdateHealthText();
        }
    }

    void TakeDamageOnClick()
    {
        TakeDamage(2);
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
