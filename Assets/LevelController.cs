using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelController instance;

    List<Vector3> powerUps;
    List<Vector3> Enemies;
    List<Vector3> Obstacales;

    [SerializeField] List<Level> levels;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        powerUps = new List<Vector3>();
        Enemies = new List<Vector3>();
        Obstacales = new List<Vector3>();
    }

    public void SetLevel(int levelIndex)
    {
        powerUps.Clear();
        Enemies.Clear();
        Obstacales.Clear();
        for(int i = 0;i<levels[levelIndex].PopUps.Count;i++)
        {
            powerUps[i] = levels[levelIndex].PopUps[i].position;
        }
        for (int i = 0; i < levels[levelIndex].Enemies.Count; i++)
        {
            Enemies[i] = levels[levelIndex].Enemies[i].position;
        }
        for (int i = 0; i < levels[levelIndex].Obstacales.Count; i++)
        {
            Obstacales[i] = levels[levelIndex].Obstacales[i].position;
        }
    }

    private void SetLevelObjects()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
