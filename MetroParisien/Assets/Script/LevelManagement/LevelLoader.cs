using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader: MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private CheckpointSaverScriptable checkpointSaver;

    private void Awake()
    {
        if(playerTransform == null)
        {
            Debug.LogError("Missing reference to playerTransform of type Vector3");
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SetPositionToLastCheckpoint;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SetPositionToLastCheckpoint;
    }

    private void SetPositionToLastCheckpoint(Scene scene, LoadSceneMode mode)
    {
        if(!checkpointSaver.teleportOnNextLoad)
        {
            checkpointSaver.teleportOnNextLoad = true;
            return;
        }
        playerTransform.position = checkpointSaver.furthestCheckpointReachedPosition;
    }


    public void reloadScene()
    {
        loadScene(SceneManager.GetActiveScene().name);
    }

    public void loadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
