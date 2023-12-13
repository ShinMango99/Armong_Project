using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStamina : MonoBehaviour
{
    public int maxStamina = 10;
    private int currentStamina;

    public staminaBar staminabar;
    public Button exhaustButton;
    public Text staminaText;

    void Start()
    {
        currentStamina = maxStamina;
        staminabar.SetMaxStamina(maxStamina);

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
}
