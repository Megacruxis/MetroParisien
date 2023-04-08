using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IOpenable
{
	[SerializeField] private OpenableManager doorManager;
	[SerializeField] private float DoorSize;

	void Awake()
	{
		doorManager.OpenableManagerButtonIsClicked.AddListener(OpenDoor);
	}

	private void OpenDoor()
	{
		gameObject.transform.position += new Vector3(0, DoorSize, 0);
		doorManager.OpenableManagerButtonIsClicked.RemoveListener(OpenDoor);
		doorManager.OpenableManagerButtonIsClicked.AddListener(CloseDoor);
	}

	private void CloseDoor()
	{
		gameObject.transform.position -= new Vector3(0, DoorSize, 0);
		doorManager.OpenableManagerButtonIsClicked.RemoveListener(CloseDoor);
		doorManager.OpenableManagerButtonIsClicked.AddListener(OpenDoor);
	}
}
