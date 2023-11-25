using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alok
{
    public class InputController : MonoBehaviour
    {

        public Vector3 inputs;

        [SerializeField] Camera playerCam;
        [SerializeField] JoyStickController joystick;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
            SystemInput();
#elif UNITY_ANDROID
            MobileInput();
#endif
        }

        private void SystemInput()
        {
            inputs.x = Input.GetAxisRaw("Horizontal");
            inputs.z = Input.GetAxisRaw("Vertical");
        }

        private void MobileInput()
        {
            inputs.x = joystick.DraggedValues().x;
            inputs.z = joystick.DraggedValues().y;
        }

        public void OnJump()
        {
            Debug.LogError("Jump");
        }

        [SerializeField] GameObject cube;
        RaycastHit hit;
        public void Fire()
        {
            Ray ray = playerCam.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2,0));
            if (Physics.Raycast(ray, out hit, 2000))
            {
                Instantiate(cube, hit.point, Quaternion.identity);
                if (hit.collider.gameObject.CompareTag("Enemy"))
                    Destroy(hit.collider.gameObject);
            }
        }

        public void ThrowBomb()
        {

        }
    }
}
