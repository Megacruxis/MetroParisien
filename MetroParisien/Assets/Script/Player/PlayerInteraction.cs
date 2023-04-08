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
        if (objects.Length == 0) return;
        foreach (var item in objects)
        {
            interactibleObject = item.GetComponent<IInteractible>();
            if (interactibleObject != null) return;
        }
    }

    public void Interact()
    {
        if (interactibleObject == null) return;
        
        if (pControler.pInput.GetInteractInput() && !interactibleObject.isActive)
        {
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
