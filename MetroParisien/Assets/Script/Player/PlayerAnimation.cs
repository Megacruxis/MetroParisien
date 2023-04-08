using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator charaAnimator;
    [Header("Movement Animation")]
    [SerializeField] private string speedParameter;
    [SerializeField] private string jumpParameter;
    [SerializeField] private string isGroundedParameter;
    [SerializeField] private string isFallingParameter;
    [SerializeField] private string isJumpingParameter;


    PlayerController pControler;
    internal void Initialize()
    {
        pControler = GetComponent<PlayerController>();
    }

    public void ChangeSpeedParameter(float value) => charaAnimator.SetFloat(speedParameter, value);

    public void TriggerJumpParameter() => charaAnimator.SetTrigger(jumpParameter);

    public void ChangeIsGroundedParameter(bool value) => charaAnimator.SetBool(isGroundedParameter, value);
    public void ChangeIsFallingParameter(bool value) => charaAnimator.SetBool(isFallingParameter, value);
    public void ChangeIsJumpingParameter(bool value) => charaAnimator.SetBool(isJumpingParameter, value);


}
