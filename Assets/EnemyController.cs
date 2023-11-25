using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] int enemyNumber = 20;
    [SerializeField] GameObject[] levelEnemy;
    [SerializeField] Transform playerTr;
    public void SetEnemy()
    {
        //GameObject thisAi;
        //for(int i=0;i< levelEnemy.Length; i++)
        //{
        //    thisAi = Instantiate(enemy, levelEnemy[i].transform.position, Quaternion.identity);
        //    thisAi.GetComponent<EnemyAi>().SetPlayerRef(playerTr);
        //}
    }
    void Start()
    {
        SetEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
