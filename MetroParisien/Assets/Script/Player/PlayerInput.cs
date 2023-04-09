using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Movement Input")]
    [SerializeField] private string xAxieInput;
    [SerializeField] private string zAxieInput;
    [SerializeField] private string jumpInput;

    [Header("Interaction")]
    [SerializeField] private string interactInput;

    [Header("reset")]
    [SerializeField] private string resetInput;

    [SerializeField] LoadLevelEventDispatcherScriptable loadLevelScriptable;


    PlayerController pControler;
    internal void Initialize()
    {
        pControler = GetComponent<PlayerController>();
    }

    public Vector3 GetMovementDirection() => new Vector3(-Input.GetAxis(xAxieInput), 0, Input.GetAxis(zAxieInput));

    public bool GetJumpInputDown() => Input.GetButtonDown(jumpInput);

    public bool GetJumpInput() => Input.GetButton(jumpInput);
    public bool GetJumpInputUp() => Input.GetButtonUp(jumpInput);

    public bool GetInteractInput() => Input.GetButtonDown(interactInput);

    public bool GetResetInput() => Input.GetButtonDown(resetInput);

    public void StartReset()
    {
        loadLevelScriptable.DisptachReloadLevel();
    }

}
