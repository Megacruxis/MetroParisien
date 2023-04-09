using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour, IButton
{
	[SerializeField] private OpenableManager doorManager;

    void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.layer!=12)
			doorManager.InteractWithDoor();
	}

    void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.layer!=12)
			doorManager.InteractWithDoor();
	}
}
