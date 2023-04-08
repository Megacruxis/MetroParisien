using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour, IButton
{
	[SerializeField] private OpenableManager doorManager;

    private void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.layer!=12)
			doorManager.InteractWithDoor();
	}

    private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer!=12)
			doorManager.InteractWithDoor();
	}
}
