using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerStamina : MonoBehaviour
{
    public int maxStamina = 10;
    private int currentStamina;

    public staminaBar staminabar;
    public Button exhaustButton;
    public TextMeshProUGUI staminaText; // Change to TextMeshProUGUI

    private float lastXPosition;

    void Start()
    {
        currentStamina = maxStamina;
        staminabar.SetMaxStamina(maxStamina);

        lastXPosition = transform.position.x;

        if (exhaustButton != null)
        {
            exhaustButton.onClick.AddListener(ExhaustOnClick);
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
            Exhaust(2);
            UpdateStaminaText();
        }

        float deltaX = Mathf.Abs(transform.position.x - lastXPosition);

        if (deltaX >= 2f)
        {
            // Player's x value has changed by 2 or more
            ReduceStamina(1); // Adjust the amount as needed
            UpdateStaminaText();
            lastXPosition = transform.position.x; // Update the last position
        }
    }

    void ExhaustOnClick()
    {
        Exhaust(2);
        UpdateStaminaText();
    }

    void Exhaust(int exhaust)
    {
        currentStamina -= exhaust;

        staminabar.SetStamina(currentStamina);
        currentStamina = Mathf.Max(currentStamina, 0);
    }

    void UpdateStaminaText()
    {
        if (staminaText != null)
        {
            staminaText.text = "Stamina: " + currentStamina.ToString();
        }
        else
        {
            Debug.LogError("Stamina Text not assigned in the inspector!");
        }
    }

    void ReduceStamina(int amount)
    {
        currentStamina -= amount;

        staminabar.SetStamina(currentStamina);
        currentStamina = Mathf.Max(currentStamina, 0);
    }
}
