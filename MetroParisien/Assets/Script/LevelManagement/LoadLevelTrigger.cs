using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LoadLevelTrigger : MonoBehaviour
{
    [SerializeField]
    private LoadLevelEventDispatcherScriptable loadLevelEventDispatcher;

    private Collider trigerZone;

    private void Awake()
    {
        trigerZone = GetComponent<Collider>();
        if (trigerZone == null)
        {
            Debug.LogError("not a collider");
        }
        if (!trigerZone.isTrigger)
        {
            Debug.LogError("not a trigger");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        loadLevelEventDispatcher.DisptachLoadLevel();
        gameObject.SetActive(false);
    }
}
