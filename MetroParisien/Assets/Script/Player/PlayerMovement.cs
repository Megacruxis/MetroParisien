using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float maxMovementSpeed;
    [SerializeField] private float initialMovementSpeed;
    [SerializeField] private float accelerationMovement;
    [Range(0,1)]
    [SerializeField] private float minValueToAccel;
    private float currentSpeed;
    private Vector3 movementValue;
    public bool canMove;

    [Header("Gravity")]
    [SerializeField] private float gravityValue;
    [SerializeField] private float groundedGravityValue;
    [SerializeField] private Vector3 gravityDirection;

    [Header("Jump")]
    //bool isJumpPressed = false;
    [SerializeField] private float jumpForce;
    //[SerializeField] private float maxJumpHeight =1.0f;
    [SerializeField] private float maxJumpTime = 0.5f;
    private bool isJumping;

    private float jumpTime;

    [Header("GroundCheck")]
    [SerializeField] private Transform groundCheckOrigin;
    [SerializeField] private float groundCheckRaduis;
    [SerializeField] private LayerMask groundCheckMask;


    PlayerController pControler;
    internal void Initialize()
    {
        pControler = GetComponent<PlayerController>();
        isJumping = false;
        jumpTime = 0;
        movementValue = Vector3.zero;
        canMove = true;
    }

    public void Move(CharacterController chara,Vector3 direction)
    {
        if (!canMove) return;
        Movement(direction);
        Gravity();
        Jump();
        //Debug.Log(movementValue);
        chara.Move(movementValue * Time.deltaTime);
        transform.LookAt(transform.position + direction);
        pControler.pAnimation.ChangeIsGroundedParameter(GroundCheck());
        
    }

    public void Movement(Vector3 direction)
    {
        if (direction.magnitude == 0)
        {
            currentSpeed = 0;
        }
        else if(direction.magnitude < minValueToAccel)
        {
            currentSpeed = Math.Clamp(currentSpeed - (accelerationMovement * Time.deltaTime), initialMovementSpeed, maxMovementSpeed);
        }
        else
        {
            currentSpeed = Math.Clamp(currentSpeed + (accelerationMovement * Time.deltaTime), initialMovementSpeed, maxMovementSpeed);
        }

        Vector3 DirectionSpeed = direction * currentSpeed;

        pControler.pAnimation.ChangeSpeedParameter(direction.magnitude);

        movementValue.x = DirectionSpeed.x;
        movementValue.z = DirectionSpeed.z;

    }

    public bool GroundCheck() => Physics.CheckSphere(groundCheckOrigin.position, groundCheckRaduis, groundCheckMask);


    public void Gravity()
    {
        
        if (GroundCheck())
        {
            movementValue.y = groundedGravityValue;
        }
        else
        {
            movementValue.y += gravityValue * Time.deltaTime;

        }

    }

    public void Jump()
    {
        
        if(GroundCheck()&& pControler.pInput.GetJumpInputDown() && !isJumping)
        {
            isJumping = true;
            jumpTime = maxJumpTime;
            movementValue.y = jumpForce;
            pControler.pAnimation.TriggerJumpParameter();
            //pControler.pAnimation.ChangeIsJumpingParameter(true);
        }
        if(isJumping=true && pControler.pInput.GetJumpInput())
        {
            if (jumpTime > 0)
            {
                movementValue.y= jumpForce;
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (pControler.pInput.GetJumpInputUp())
        {
            isJumping = false;
        }
        if (GroundCheck())
        {
            isJumping = false;
            //pControler.pAnimation.ChangeIsJumpingParameter(false);
        }
    }


}
