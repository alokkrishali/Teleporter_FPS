using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] int EnemyPoints = 5;
    [SerializeField] float Speed = 30;
    public bool CanMove = false;
    Transform thisTransform;
    [SerializeField]
    private Transform startPos;
    private Transform currentTarget;
    [SerializeField]
    float attackingThresold = 36;
    [SerializeField]
    private int HelthValue = 3;
    private Transform _playerTr;
    // Start is called before the first frame update
    Animator enemyAnim;

    [SerializeField] float rotationSpeed = 10;
    void Start()
    {
        thisTransform = GetComponent<Transform>();
        enemyAnim = GetComponent<Animator>();
        enemyAnim.SetInteger("State", 0);
    }

    public void SetPlayerRef(Transform playerTr)
    {
        _playerTr = playerTr;
        if (_playerTr == null)
        {
            Debug.Log("Player is away from Enemy");
            CheckDistance = false;
            IsPlayerNear = false;
            currentTarget = startPos;
            enemyAnim.SetInteger("State", 1);
            CanMove = true;
            Invoke("GoBackToStartPos", 4);
        }
        else
        {
            Debug.Log("Player is near to Enemy");
            CheckDistance = true;
            IsPlayerNear = true;
            CheckPlayerPos();
            currentTarget = _playerTr;
            enemyAnim.SetInteger("State", 1);
        }
    }
    private void GoBackToStartPos()
    {
        enemyAnim.SetInteger("State", 0);
        CanMove = false;
        currentTarget = null;
    }
    public void ReduceHelth()
    {
        HelthValue--;
        if (HelthValue <= 0)
        {
            enemyAnim.SetBool("dead", true);
            ScoreManager.instance.UpdateScore(5);
        }
    }
    bool IsPlayerNear = false, CheckDistance = true;

    public void CheckPlayerPos()
    {
        if (checkPlayerPos != null)
            StopCoroutine(checkPlayerPos);
        checkPlayerPos = StartCoroutine(CheckPlayer());
    }
    float playerDistance = 0;
    IEnumerator CheckPlayer()
    {
        while (CheckDistance)
        {
            playerDistance = Vector3.SqrMagnitude(thisTransform.position - _playerTr.position);
            Debug.Log("Disdtance - "+ playerDistance);
            if (playerDistance < attackingThresold)
            {
                Debug.Log("attackingThresold - " + attackingThresold);
                CanMove = false;
                enemyAnim.SetInteger("State", 2);
            }
            yield return new WaitForSeconds(1);
        }
    }

    private void MovePlayerTowards()
    {
        Quaternion lookAt = Quaternion.LookRotation(currentTarget.position - thisTransform.position);
        thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation, lookAt, Time.deltaTime * 10);
        MoveTowardsPlayer();
    }
    [SerializeField] float moveSpeed = 30;
    void MoveTowardsPlayer()
    {
       thisTransform.position = Vector3.MoveTowards(thisTransform.position, currentTarget.position, Time.deltaTime* moveSpeed);
    }
    // Update is called once per frame
    Coroutine checkPlayerPos;
    void Update()
    {
        if(CanMove)
        {
            MovePlayerTowards();
        }
    }

    public void OnHit()
    {
        Destroy(gameObject);
    }
}
