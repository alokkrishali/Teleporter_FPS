using UnityEngine;
using System.Collections;

namespace Alok
{
	public class BallController : MonoBehaviour
	{

		[SerializeField]
		JoyStickController myJoystick;
		[SerializeField]
		float Speed = 5;
		Vector3 MoveVector = Vector3.zero;

		Rigidbody rdBall;

		void Start()
		{

			rdBall = GetComponent<Rigidbody>();
		}
		void Update()
		{
			MoveVector = myJoystick.DraggedValues();
			rdBall.AddForce(MoveVector * Speed);
		}
	}
}
