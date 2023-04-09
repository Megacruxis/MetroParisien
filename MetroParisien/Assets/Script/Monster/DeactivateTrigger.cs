using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateTrigger : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> itemToDeactivate;

    [SerializeField]
    private BakeNavemeshEventDispatcherScriptable bakeNaveMeshEventDispatcher;

    private void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject item in itemToDeactivate)
        {
            item.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
