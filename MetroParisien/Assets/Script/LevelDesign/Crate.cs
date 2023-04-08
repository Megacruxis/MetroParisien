using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour ,IInteractible
{
	private bool playerInRange;

    public bool isActive { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Activate()
    {
        throw new System.NotImplementedException();
    }

    public void Disable()
    {
        throw new System.NotImplementedException();
    }















    /*private bool PlayerIsNear = false;
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
	}*/

}
