using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour ,IInteractible
{
    [Header("Movement")]
    [SerializeField] private float distanceMovement;
    [SerializeField] private float vitesseMovement;
    [SerializeField] private Rigidbody rigid;

    [Header("Direction Check")]
    [SerializeField] private Transform checkOrigin;
    [SerializeField] private float checkLenght;
    [SerializeField] private float checkRaduis;
    [SerializeField] private LayerMask playerMask;

    [Header("MovementCheck")]
    [SerializeField] private float movementRaduisCheck;

    [Header("Event disptacher")]
    [SerializeField] private BakeNavemeshEventDispatcherScriptable bakeNavemeshEventDispatcher;

    public bool isActive { get ; set ; }

    PlayerController pControler;

    private void Awake()
    {
        isActive = false;
        pControler = FindAnyObjectByType<PlayerController>();
    }

    public void Activate()
    {
        if (isActive) return;
        //Debug.Log("Start");
        Vector3 directionToMove = GetMoveDirection();
        //Debug.Log(directionToMove);
        if (CheckIfCrateCanMove(directionToMove))
        {
            //Debug.Log("StartCoroutine");
            StartCoroutine(MovingCrate(directionToMove));
        }
        
    }

    public void Disable()
    {
        isActive = false;
    }

    public bool CheckIfCrateCanMove(Vector3 direction)
    {
        if(direction==Vector3.zero)return false;
        else
        {
            if (Physics.CheckSphere(checkOrigin.position + direction * distanceMovement, movementRaduisCheck)) return false;
            return true;
        }
    }

    public Vector3 GetMoveDirection()
    {
        //le joueur est a droite renvoie gauche
        if (Physics.CheckCapsule(checkOrigin.position, checkOrigin.position + transform.right, checkRaduis, playerMask)) return -transform.right;
        //le joueur est a gauche renvoie droite
        else if (Physics.CheckCapsule(checkOrigin.position, checkOrigin.position - transform.right, checkRaduis, playerMask)) return transform.right;
        //le joueur est devant renvoie derrier
        else if (Physics.CheckCapsule(checkOrigin.position, checkOrigin.position + transform.forward, checkRaduis, playerMask)) return -transform.forward;
        //Le joueur est derrier renvoie devant
        else if (Physics.CheckCapsule(checkOrigin.position, checkOrigin.position - transform.forward, checkRaduis, playerMask)) return transform.forward;
        //le joueur est nulle part
        return Vector3.zero;
    }


    public IEnumerator MovingCrate(Vector3 Direction)
    {
        isActive = true;
        pControler.pMovement.canMove = false;
        Vector3 newPoint = transform.position + Direction * distanceMovement;
        rigid.isKinematic = true;
        //Debug.Log("Start Moving");
        while (Vector3.Distance(newPoint,transform.position)>0.05f)
        {
            transform.Translate(Direction * vitesseMovement * Time.deltaTime);
            bakeNavemeshEventDispatcher.DisatchBakeNavemesh();
            yield return Time.deltaTime;
        }
        transform.position = newPoint;
        pControler.pMovement.canMove = true;
        rigid.isKinematic = false;
        Disable();
    }













    

}
