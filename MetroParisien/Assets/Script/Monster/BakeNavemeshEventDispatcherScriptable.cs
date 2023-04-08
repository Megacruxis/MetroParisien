using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BakeNavemesh", menuName = "EventDispatcher/BakeEventDispatcher")]
public class BakeNavemeshEventDispatcherScriptable : EventDispatcherScriptable
{
    public void DisatchBakeNavemesh()
    {
        dispatchedEvents[0].Invoke();
    }
}
