using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private CheckpointSaverScriptable checkpointSaver;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("saved");
            checkpointSaver.furthestCheckpointReachedPosition = transform.position;
        }
    }
}
