using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] GameObject Enemy, Boss;

    [SerializeField] int NumberOfEnemy = 3;
    bool PlayerNearBy = false;

    [SerializeField] Transform playerTr;
    [SerializeField]
    List<Transform> enemy = new List<Transform>();

    Transform thisTransform;
    private void Start()
    {
        thisTransform = GetComponent<Transform>();
    }
    private void GenerateEnemy()
    {
        GameObject thisEnemy = null;
        Vector3 pos = thisTransform.position;
        for (int i=0;i<NumberOfEnemy;i++)
        {
            pos.x += i;
            if (enemy != null)
                thisEnemy = Instantiate(Enemy, pos, Quaternion.identity);
            thisEnemy.GetComponent<EnemyAi>().SetPlayerRef(playerTr);
            enemy.Add(thisEnemy.transform);
        }
        if (Boss != null)
        {
            thisEnemy = Instantiate(Boss, pos, Quaternion.identity);
            thisEnemy.GetComponent<EnemyAi>().SetPlayerRef(playerTr);
            enemy.Add(thisEnemy.transform);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            EnemyAi mEnemy = null;
            PlayerNearBy = true;
            //Debug.LogError("Enter in Range");
            for (int i = 0; i < enemy.Count; i++)
            {
                mEnemy = enemy[i].GetComponent<EnemyAi>();
            }
            if(mEnemy != null)
            {
                mEnemy.CanMove = true;
                mEnemy.SetPlayerRef(other.gameObject.transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnemyAi mEnemy = null;
            PlayerNearBy = true;
            //Debug.LogError("Enter in Range");
            for (int i = 0; i < enemy.Count; i++)
            {
                mEnemy = enemy[i].GetComponent<EnemyAi>();
            }
            if (mEnemy != null)
            {
                mEnemy.CanMove = false;
                mEnemy.SetPlayerRef(null);
            }
        }
    }


}
