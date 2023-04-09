using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private Transform originDetection;
    [SerializeField] private float raduisDetection;
    [SerializeField] private float lenghtDetection;
    [SerializeField] private LayerMask maskDetection;

    private IInteractible interactibleObject;

    PlayerController pControler;
    internal void Initialize()
    {
        pControler = GetComponent<PlayerController>();
    }

    public void GetInteractibleObject()
    {
        Collider[] objects = Physics.OverlapCapsule(originDetection.position, originDetection.position + (originDetection.forward * lenghtDetection), raduisDetection, maskDetection);
        if (objects.Length == 0) {
			interactibleObject = null;
            pControler.pSfx.interactibleSoundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            return;	
		} 
        foreach (var item in objects)
        {
            interactibleObject = item.GetComponent<IInteractible>();
            //Debug.Log(interactibleObject);
            if (interactibleObject != null) 
            {
                pControler.pSfx.interactibleSoundInstance.start();
                return;
            } 
        }
    }

    public void Interact()
    {
        if (interactibleObject == null||!pControler.pMovement.GroundCheck()) return;
        Debug.Log("Can Interact");
        if (pControler.pInput.GetInteractInput() && !interactibleObject.isActive)
        {
            Debug.Log("StartInteract");
            interactibleObject.Activate();
        }

        if ((pControler.pInput.GetInteractInput() || IsInputMovementAnotherDirection()) && interactibleObject.isActive)
        {
            interactibleObject.Disable();
        }

    }


    public bool IsInputMovementAnotherDirection()
    {
        return false;
    }
}
