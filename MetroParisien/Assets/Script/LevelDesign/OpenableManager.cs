using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New OpenableManager", menuName = "EventDispatcher/OpenableManager")]
public class OpenableManager : EventDispatcherScriptable
{
	public void InteractWithDoor()
	{
		DispatchEvent(0);
	}
}
