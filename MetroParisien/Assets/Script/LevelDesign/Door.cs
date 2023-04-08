using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IOpenable
{
	[SerializeField] private OpenableManager doorManager;
	[SerializeField] private float DoorSize;

	void Awake()
	{
		doorManager.dispatchedEvents[0].AddListener(OpenDoor);
	}

	private void OpenDoor()
	{
		gameObject.transform.position += new Vector3(0, DoorSize, 0);
		doorManager.dispatchedEvents[0].RemoveListener(OpenDoor);
		doorManager.dispatchedEvents[0].AddListener(CloseDoor);
	}

	private void CloseDoor()
	{
		gameObject.transform.position -= new Vector3(0, DoorSize, 0);
		doorManager.dispatchedEvents[0].RemoveListener(CloseDoor);
		doorManager.dispatchedEvents[0].AddListener(OpenDoor);
	}
}
