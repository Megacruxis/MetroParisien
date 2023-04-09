using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private CheckpointSaverScriptable checkpointSaver;

    [SerializeField]
    private Vector3 checkpointPosition = Vector3.zero;

    [Header("Fmod checkpoint reached sound")]
    public EventReference checkpointReachedEvent;
    FMOD.Studio.EventInstance checkpointReachedInstance;

    private bool alreadyReched = false;

    private void Start()
    {
        checkpointReachedInstance = RuntimeManager.CreateInstance(checkpointReachedEvent);
        if(checkpointSaver.furthestCheckpointReachedPosition == checkpointPosition)
        {
            alreadyReched = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyReched && other.gameObject.tag == "Player")
        {
            checkpointReachedInstance.start();
            checkpointSaver.furthestCheckpointReachedPosition = checkpointPosition;
            alreadyReched = true;
        }
    }
}
