using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New OpenableManager", menuName = "OpenableManager")]
public class OpenableManager : ScriptableObject
{
	public UnityEvent OpenableManagerButtonIsClicked;

	private void OnEnable()
	{
		OpenableManagerButtonIsClicked = new UnityEvent();
	}

	public void InteractWithDoor()
	{
		OpenableManagerButtonIsClicked.Invoke();
	}
}
