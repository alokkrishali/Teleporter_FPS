using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alok
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] InputController inputCtrl;
        [SerializeField]
        private Vector3 playerInput;
        private Transform playerTr;
        private Rigidbody playerBody;
        CharacterController charCtrl;
        [SerializeField] float Speed = 10, rotationSpeed = 20;
        [SerializeField] Animator anim;
        [SerializeField] AnimationController playerAnimCtr;

        float gravity = -9.81f;
        [SerializeField] float gravityMultiplier = 3;
        [SerializeField]
         Vector3  _velocity;
        [SerializeField] Transform groundObject;
        [SerializeField] float bombThrowSpeed = 4;

        private void Awake()
        {
            charCtrl = GetComponent<CharacterController>();
            playerTr = GetComponent<Transform>();
            playerBody = GetComponent<Rigidbody>();
        }
        // Start is called before the first frame update
        void Start()
        {
            playerAnimCtr.SetGunType(playerAnim.Player4);
        }
        [SerializeField]
        Vector3 targetAngle;
        // Update is called once per frame
        void Update()
        {
            Movement();
            Rotation();
            playerAnimCtr.SetMove(inputCtrl.inputs.z);
        }

       
        [SerializeField] float characterSkinThikness;
        bool IsGrounded()
        {
            if(Physics.Raycast(transform.position, -Vector3.up, characterSkinThikness))
            {
                Debug.Log("Yes,Grounded");
                return true;
            }
            else
            {
                Debug.Log("No,Not Grounded");
                return false;
            }
        }
        void Movement()
        {
            if (IsJump && _velocity.y < 0)
            {
                _velocity.y = -2;
            }
            charCtrl.Move(playerTr.forward * inputCtrl.inputs.z * Speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) || IsJump)
            {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                IsJump = false;
            }
            _velocity.y += gravity * Time.deltaTime * gravityMultiplier;

            charCtrl.Move(_velocity * Time.deltaTime);
        }

        void Rotation()
        {
            targetAngle = new Vector3(0, inputCtrl.inputs.x * rotationSpeed * Time.deltaTime, 0);
            playerTr.Rotate(targetAngle);
        }

        public void SetFire()
        {
            inputCtrl.Fire();
            playerAnimCtr.SetFire();
        }

        [SerializeField] Rigidbody bomb;
        Vector3 forceDir;
        [SerializeField] Transform cameraTr;

        [SerializeField] Transform bombPoint;
        public void SetBomb()
        {
            Debug.Log(" Camera X angle : "+ cameraTr.localEulerAngles.x);
            bomb.transform.position = bombPoint.position;
            bomb.velocity = Vector3.zero;
            if (cameraTr.localEulerAngles.x != 0)
            {
                if(cameraTr.localEulerAngles.x>100)
                    forceDir = playerTr.forward * bombThrowSpeed + new Vector3(0, (360 - cameraTr.localEulerAngles.x), 0) * .25f;
                else
                    forceDir = playerTr.forward * bombThrowSpeed - new Vector3(0, (cameraTr.localEulerAngles.x), 0) * .25f;
            }
            else
                forceDir = playerTr.forward * bombThrowSpeed;
            bomb.GetComponent<Bomb>().onThrow();
            bomb.AddForce(forceDir, ForceMode.Impulse);
        }

        [SerializeField] float jumpHeight = 3;
        bool IsJump = false;
        public void jump()
        {
            Debug.LogError("Jump");
            if (IsGrounded())
            IsJump = true;
        }
    }
}
