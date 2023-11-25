using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alok
{
    public class PlayerFollow : MonoBehaviour
    {
        public Transform player_Tr;
        private Transform cameraTr;
        private float offsetValue = 0;
        [SerializeField] float mouseSensitivity = 100;

        private void Awake()
        {
            cameraTr = GetComponent<Transform>();
        }
        void Start()
        {

        }

        float cameraRot = 0;
        private void Update()
        {
            CameraUpDownRotation();
        }

        private void CameraUpDownRotation()
        {
            if (Input.mousePosition.x > Screen.width / 3 && Input.mousePosition.x < Screen.width * 2 / 3)
            {
                if (Input.GetMouseButton(0))
                {
                    Debug.Log("Angle - "+ cameraTr.eulerAngles.x);
                    Debug.Log("Angle 2- " + cameraTr.localEulerAngles.x);
                    cameraRot += Input.GetAxis("Mouse Y")* mouseSensitivity*Time.deltaTime;
                    cameraTr.rotation = Quaternion.Euler(Mathf.Clamp(cameraRot, -15, 15), cameraTr.eulerAngles.y, 0);
                }
            }
        }


    }
}
