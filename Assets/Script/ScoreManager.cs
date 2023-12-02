using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score = 0;
    private int PowerUp = 0;

    [SerializeField] List<int> LevelCompleteScore;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        score = 0;
    }

    public void ResetPowerUps()
    {
        PowerUp = 0;
    }
    public void ResetScore()
    {
        score = 0;
    }
    public void UpdateScore(int value)
    {
        score += value;
        UiManager.instance.UpdatedScore();
    }
    public void UpdatePowerUps(int value)
    {
        PowerUp += value;
        if (PowerUp > LevelCompleteScore[LevelController.instance.GetLevel()])
            UiManager.instance.ShowLevelClear();
        UiManager.instance.UpdatedPowerUp();
    }

    public int GetScore()
    {
        return score;
    }
    public int GetPowerUps()
    {
        return PowerUp;
    }
}
