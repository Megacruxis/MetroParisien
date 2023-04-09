using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private CheckpointSaverScriptable checkpointSaver;

    [Header("Fmod checkpoint reached sound")]
    public EventReference checkpointReachedEvent;
    FMOD.Studio.EventInstance checkpointReachedInstance;

    private bool alreadyReched = false;

    private void Start()
    {
        checkpointReachedInstance = RuntimeManager.CreateInstance(checkpointReachedEvent);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyReched && other.gameObject.tag == "Player")
        {
            checkpointReachedInstance.start();
            checkpointSaver.furthestCheckpointReachedPosition = transform.position;
            alreadyReched = true;
        }
    }
}
