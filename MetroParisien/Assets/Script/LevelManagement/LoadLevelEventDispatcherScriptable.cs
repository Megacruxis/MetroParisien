using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New LoadLevelDispatcher", menuName = "EventDispatcher/LoadLevelDispatcher")]
public class LoadLevelEventDispatcherScriptable : EventDispatcherScriptable
{
	public const int RELOAD_LEVEL_EVENT = 0;
	public const int LOAD_LEVEL_EVENT = 1;

	protected new void OnEnable()
	{
		dispatchedEvents = new List<UnityEvent>();

		dispatchedEvents.Add(new UnityEvent());
		dispatchedEvents.Add(new UnityEvent());
	}

	public void DisptachReloadLevel()
	{
		dispatchedEvents[RELOAD_LEVEL_EVENT].Invoke();
	}

	public void DisptachLoadLevel()
	{
		dispatchedEvents[LOAD_LEVEL_EVENT].Invoke();
	}
}
