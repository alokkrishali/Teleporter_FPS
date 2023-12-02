using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alok
{
    public enum playerAnim {Player1 = 0, Player2, Player3, Player4}
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] Animator[] playerAnims;
        [SerializeField] GameObject[] player;
        private Animator currentAnimator;
        [SerializeField] private playerAnim ePlayerAnim;
        [SerializeField] ParticleSystem [] fireEffect;
        private void SetPlayerAnim()
        {
            DisablePlayers();
            currentAnimator = playerAnims[(int)ePlayerAnim];
            player[(int)ePlayerAnim].SetActive(true);
        }

        private void DisablePlayers()
        {
            for(int i=0;i<player.Length;i++)
            {
                player[i].SetActive(false);
            }
        }
        //private void OnGUI()
        //{
        //    if (GUI.Button(new Rect(0, 100, 100, 100), "SEt"))
        //    {
        //        SetPlayerAnim();
        //    }
        //    if (GUI.Button(new Rect(100,100,100,100),"Idle"))
        //    {
        //        currentAnimator.SetFloat("State", .12f);
        //    }
        //    if (GUI.Button(new Rect(200, 100, 100, 100), "Walk"))
        //    {
        //        currentAnimator.SetFloat("State", .35f);
        //    }
        //    if (GUI.Button(new Rect(300, 100, 100, 100), "Run"))
        //    {
        //        currentAnimator.SetFloat("State", .55f);
        //    }
        //    if (GUI.Button(new Rect(400, 100, 100, 100), "WalkBack"))
        //    {
        //        currentAnimator.SetFloat("State", .24f);
        //    }
        //    if (GUI.Button(new Rect(500, 100, 100, 100), "Fire"))
        //    {
        //        currentAnimator.SetTrigger("Shot");
        //    }

        //}

        public void SetFire()
        {
            currentAnimator.SetTrigger("Shot");
            fireEffect[(int)ePlayerAnim].Play();
        }
        public void SetMove(float moveValue)
        {
            currentAnimator.SetFloat("State", moveValue);
        }

        public void SetGunType(playerAnim playerAnim )
        {
            ePlayerAnim = playerAnim;
            SetPlayerAnim();
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
