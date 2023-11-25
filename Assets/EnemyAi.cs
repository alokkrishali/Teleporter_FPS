using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    //[SerializeField] Vector3 stratPos, TargetPos;
    [SerializeField] float Speed = 30;
    public bool CanMove = false;
    Transform thisTransform;
    private Vector3 currentTargetPos;
    private int HelthValue = 3;
    [SerializeField]
    private Transform _playerTr;
    // Start is called before the first frame update
    Animator enemyAnim;

    [SerializeField] float rotationSpeed = 10;
    void Start()
    {
        HelthValue = 3;
        thisTransform = GetComponent<Transform>();
        Speed = Random.Range(2, Speed);
        enemyAnim = GetComponent<Animator>();
        enemyAnim.SetInteger("State", 0);
    }

    public void SetPlayerRef(Transform playerTr)
    {
        _playerTr = playerTr;
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
    IEnumerator CheckPlayer()
    {
        while(CheckDistance)
        {
            if(_playerTr != null)
            {
                if (Vector3.SqrMagnitude(thisTransform.position - _playerTr.position) < 9)
                {
                    IsPlayerNear = true;
                    CanMove = false;
                    enemyAnim.SetInteger("State", 2);
                }
                else
                {
                    IsPlayerNear = false;
                    enemyAnim.SetInteger("State", 1);
                }
            }
            
            yield return new WaitForSeconds(2);
        }
    }

    [SerializeField] float moveSpeed = 30;
    void MoveTowardsPlayer()
    {
        if (_playerTr == null) return;
            thisTransform.position = Vector3.MoveTowards(thisTransform.position, _playerTr.position, Time.deltaTime* moveSpeed);
    }
    // Update is called once per frame
    Coroutine checkPlayerPos;
    void Update()
    {
        if(CanMove)
        {
            if (_playerTr == null) return;
            Quaternion lookAt = Quaternion.LookRotation(_playerTr.position - thisTransform.position);
            thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation, lookAt, Time.deltaTime*10);
            MoveTowardsPlayer();
            checkPlayerPos = StartCoroutine(CheckPlayer());
        }
        else
        {
            if (checkPlayerPos != null)
            {
                StopCoroutine(checkPlayerPos);
                checkPlayerPos = null;
            }
        }
    }

    public void OnHit()
    {
        Destroy(gameObject);
    }
}
