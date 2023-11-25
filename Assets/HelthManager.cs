using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthManager : MonoBehaviour
{
    public static HelthManager instance;
    private int playerHelth = 5;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void ResetHelth()
    {
        playerHelth = 5;
    }

    public void UpdateHelth(int helthValue)
    {
        playerHelth -= helthValue;
        if (playerHelth <= 0)
            UiManager.instance.ShowLevelFailed();
    }
}
