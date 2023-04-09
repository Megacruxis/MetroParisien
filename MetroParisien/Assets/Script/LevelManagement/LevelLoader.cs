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

    private string nextSceneName;

    [SerializeField]
    private LoadLevelEventDispatcherScriptable loadLevelEventDispatcher;

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
        loadLevelEventDispatcher.dispatchedEvents[LoadLevelEventDispatcherScriptable.LOAD_LEVEL_EVENT].AddListener(loadNextScene);
        loadLevelEventDispatcher.dispatchedEvents[LoadLevelEventDispatcherScriptable.RELOAD_LEVEL_EVENT].AddListener(reloadScene);
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

    public void loadNextScene()
    {
        loadScene(nextSceneName);
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
