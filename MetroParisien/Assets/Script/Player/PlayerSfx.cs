using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayerSfx : MonoBehaviour
{
    [Header("Movement Sound")]
    [SerializeField] private EventReference walkSoundEvent;
    public FMOD.Studio.EventInstance walkSoundInstance;

    [SerializeField] private EventReference jumpSoundEvent;
    public FMOD.Studio.EventInstance jumpSoundInstance;

    [SerializeField] private EventReference landingSoundEvent;
    public FMOD.Studio.EventInstance landingSoundInstance;


    [Header("Interraction")]
    [SerializeField] private EventReference interactibleSoundEvent;
    public FMOD.Studio.EventInstance interactibleSoundInstance;

    PlayerController pControler;
    internal void Initialize()
    {
        pControler = GetComponent<PlayerController>();
        walkSoundInstance = RuntimeManager.CreateInstance(walkSoundEvent);
        jumpSoundInstance = RuntimeManager.CreateInstance(jumpSoundEvent);
        interactibleSoundInstance = RuntimeManager.CreateInstance(interactibleSoundEvent);
    }

    
}
