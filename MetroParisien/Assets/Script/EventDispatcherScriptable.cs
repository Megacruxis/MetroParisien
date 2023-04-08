using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventDispatcherScriptable : ScriptableObject
{
	public List<UnityEvent> dispatchedEvents;

	protected void OnEnable()
	{
		dispatchedEvents = new List<UnityEvent>();
		dispatchedEvents.Add(new UnityEvent());
	}

	protected bool DispatchEvent(int eventIndex)
	{
		if (eventIndex >= dispatchedEvents.Count)
			return false;

		dispatchedEvents[eventIndex].Invoke();
		return true;
	}
}
