using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    [SerializeField] List<GameObject> Levels;
    [SerializeField] List<GameObject> Points;


    private int LevelNumber = 0;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public int GetLevel()
    {
        return LevelNumber;
    }

    public void SetLevel(int levelIndex)
    {
        if (levelIndex >= 3) return;
        LevelNumber = levelIndex;
        
    }

    public void ShowLevel()
    {
        DisableLeves();
        DisablePoints();
        Levels[LevelNumber].SetActive(true);
        Points[LevelNumber].SetActive(true);
    }
    private void DisableLeves()
    {
        for (int i=0;i< Levels.Count;i++)
        {
            Levels[i].SetActive(false);
        }

    }
    private void DisablePoints()
    {
        for (int i = 0; i < Points.Count; i++)
        {
            Points[i].SetActive(false);
        }
    }
}
