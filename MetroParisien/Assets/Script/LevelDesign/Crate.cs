using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
	private bool PlayerIsNear = false;
	private PlayerController player;


	

	void OnCollisionStay(Collision collisionInfo)
	{
		Debug.Log(collisionInfo.gameObject.name);
		if (collisionInfo.gameObject.tag=="Player")
		{
			if (Input.GetKey(KeyCode.E))
			{
				PlayerIsNear = true;
				Player = collisionInfo.gameObject;
				Debug.Log(Player.transform.eulerAngles);
			}
		}
	}

	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag=="Player")
			PlayerIsNear = false;
	}

}
