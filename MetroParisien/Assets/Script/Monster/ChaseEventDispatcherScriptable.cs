using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New chase event disptacher", menuName = "EventDispatcher/ChaseEventDispatcher")]
public class ChaseEventDispatcherScriptable : EventDispatcherScriptable
{
	public const int START_CHASE_EVENT_INDEX = 0;
	public const int STOP_CHASE_EVENT_INDEX = 1;

	protected new void OnEnable()
	{
		dispatchedEvents = new List<UnityEvent>();

		dispatchedEvents.Add(new UnityEvent());
		dispatchedEvents.Add(new UnityEvent());
	}

	public void DisptachStartChase()
    {
		dispatchedEvents[START_CHASE_EVENT_INDEX].Invoke();
    }

	public void DisptachStopChase()
    {
		dispatchedEvents[START_CHASE_EVENT_INDEX].Invoke();
    }

}
