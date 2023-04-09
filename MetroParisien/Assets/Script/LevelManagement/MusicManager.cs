using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicManager : MonoBehaviour
{

    [SerializeField]
    private ChaseEventDispatcherScriptable chaseEventDispatcher;

    [Header("Fmod main music event")]
    public EventReference mainMusicRef;
    FMOD.Studio.EventInstance mainMusicInstance;

    [Header("Fmod chase music event")]
    public EventReference chaseMusicRef;
    FMOD.Studio.EventInstance chaseMusicInstance;

    private void Awake()
    {
        mainMusicInstance = RuntimeManager.CreateInstance(mainMusicRef);
        chaseMusicInstance = RuntimeManager.CreateInstance(chaseMusicRef);
    }

    private void Start()
    {
        PlayMainMusic();
    }

    private void OnEnable()
    {
        chaseEventDispatcher.dispatchedEvents[ChaseEventDispatcherScriptable.START_CHASE_EVENT_INDEX].AddListener(PlayChaseMusic);
        chaseEventDispatcher.dispatchedEvents[ChaseEventDispatcherScriptable.STOP_CHASE_EVENT_INDEX].AddListener(PlayMainMusic);
    }

    private void OnDisable()
    {
        chaseEventDispatcher.dispatchedEvents[ChaseEventDispatcherScriptable.START_CHASE_EVENT_INDEX].AddListener(PlayChaseMusic);
        chaseEventDispatcher.dispatchedEvents[ChaseEventDispatcherScriptable.STOP_CHASE_EVENT_INDEX].AddListener(PlayMainMusic);
        mainMusicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        chaseMusicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    private void PlayMainMusic()
    {
        mainMusicInstance.start();
        chaseMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    private void PlayChaseMusic()
    {
        mainMusicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        chaseMusicInstance.start();
    }
}
