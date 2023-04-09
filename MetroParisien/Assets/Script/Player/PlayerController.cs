using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInteraction))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(PlayerFx))]
[RequireComponent(typeof(PlayerSfx))]

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public CharacterController characController;
    [HideInInspector]
    public PlayerMovement pMovement;
    [HideInInspector]
    public PlayerInteraction pInteraction;
    [HideInInspector]
    public PlayerInput pInput;
    [HideInInspector]
    public PlayerAnimation pAnimation;
    [HideInInspector]
    public PlayerFx pFx;
    [HideInInspector]
    public PlayerSfx pSfx;

    private void Awake()
    {
        characController = this.GetComponent<CharacterController>();

        pMovement = GetComponent<PlayerMovement>();
        pMovement.Initialize();

        pInteraction = GetComponent<PlayerInteraction>();
        pInteraction.Initialize();

        pInput = GetComponent<PlayerInput>();
        pInput.Initialize();

        pAnimation = GetComponent<PlayerAnimation>();
        pAnimation.Initialize();

        pFx = GetComponent<PlayerFx>();
        pFx.Initialize();

        pSfx = GetComponent<PlayerSfx>();
        pSfx.Initialize();
    }


    private void Update()
    {
        pMovement.Move(characController,pInput.GetMovementDirection());
        pInteraction.GetInteractibleObject();
        pInteraction.Interact();
        if (pInput.GetResetInput()) pInput.StartReset();
    }






}
