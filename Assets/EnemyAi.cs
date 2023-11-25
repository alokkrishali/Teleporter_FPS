using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    //[SerializeField] Vector3 stratPos, TargetPos;
    [SerializeField] float Speed = 30;
    public bool CanMove = false;
    Transform thisTransform;
    [SerializeField]
    private Transform startPos;
    private Transform currentTarget;
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
            Invoke("GoBackToStartPos", 1);
            IsPlayerNear = false;
            currentTarget = startPos;
        }
        else
        {
            CheckDistance = true;
            IsPlayerNear = true;
            CheckPlayerPos();
            currentTarget = _playerTr;
            enemyAnim.SetInteger("State", 1);
        }
    }
    private void GoBackToStartPos()
    {
        enemyAnim.SetInteger("State", 1);
        CanMove = true;
    }
    public void ReduceHelth()
    {
        HelthValue--;
        if (HelthValue <= 0)
        {
            enemyAnim.SetBool("dead", true);
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
            if(_playerTr != null)
                playerDistance = Vector3.SqrMagnitude(thisTransform.position - _playerTr.position);
            Debug.Log("Disdtance - "+ playerDistance);
            if (playerDistance < 36)
            {
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
