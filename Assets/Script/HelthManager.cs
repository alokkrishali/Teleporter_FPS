using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthManager : MonoBehaviour
{
    public static HelthManager instance;
    private int playerHealth = 5;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void ResetHealth()
    {
        playerHealth = 5;
    }

    public void UpdateHealth(int helthValue)
    {
        playerHealth -= helthValue;
        if (playerHealth <= 0)
            UiManager.instance.ShowLevelFailed();
        UiManager.instance.UpdatedHealth();
    }

    public int GetHealth()
    {
        return playerHealth;
    }
}
