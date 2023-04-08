using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCheckpointSaver", menuName = "Utils/CheckpointSaverScriptable")]
public class CheckpointSaverScriptable : ScriptableObject
{
    public string linkedSceneName = "MainMenu";
    public Vector3 furthestCheckpointReachedPosition = Vector3.zero;
}
