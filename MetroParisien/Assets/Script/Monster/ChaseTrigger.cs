using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ChaseTrigger : MonoBehaviour
{
    [SerializeField]
    private ChaseEventDispatcherScriptable chaseEventDispatcher;

    [SerializeField]
    private bool isStarting;

    private Collider trigerZone;

    private void Awake()
    {
        trigerZone = GetComponent<Collider>();
        if(trigerZone == null)
        {
            Debug.LogError("not a collider");
        }
        if(!trigerZone.isTrigger)
        {
            Debug.LogError("not a trigger");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isStarting)
            chaseEventDispatcher.DisptachStartChase();
        else
            chaseEventDispatcher.DisptachStopChase();
        gameObject.SetActive(false);
    }
}
