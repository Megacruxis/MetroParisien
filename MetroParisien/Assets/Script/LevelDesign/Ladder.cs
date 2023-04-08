using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private GameObject Player;
	[SerializeField] private float VerticalSpeed; 

	private Rigidbody PlayerRigidbody; 
	private bool isClimbing = false;
	private Vector3 VerticalMove;

	void Start()
	{
		PlayerRigidbody = Player.GetComponent<Rigidbody>();
	}
	
	void OnCollisionExit(Collision collisionInfo)
	{
		isClimbing = false;
	}

	void OnCollisionStay(Collision collisionInfo)
	{
		if (collisionInfo.gameObject==Player){
			if (Input.GetKey(KeyCode.E))
				isClimbing = true;

			if (Input.anyKeyDown){
				isClimbing = false;
				Debug.Log(isClimbing);
			}

			if (isClimbing)
			{
				VerticalMove = new Vector3(0, Time.deltaTime * VerticalSpeed, 0);
				PlayerRigidbody.AddForce(VerticalMove);
			}
		}
	}
}
