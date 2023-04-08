using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour, IInteractible
{
    [SerializeField] private PlayerController player;
	[SerializeField] private float verticalSpeed;
	[SerializeField] private float timeClimb;

	private bool isClimbing;

    public bool isActive { get ; set  ; }

    void Awake()
	{
        if (player == null)
        {
			player = FindAnyObjectByType<PlayerController>();
        }
		isClimbing = false;
	}

	public void Activate()
	{
		isActive = true;
		StartCoroutine(ClimbLader());
	}

	public void Disable()
	{
		isActive = false;
	}

	public IEnumerator ClimbLader()
    {
		isClimbing = true;
		player.pMovement.canMove = false;
		float currentTime = 0;
        while(isActive || currentTime < timeClimb)
        {
			player.characController.Move(Vector3.up * verticalSpeed * Time.deltaTime);
			currentTime += Time.deltaTime;
			yield return Time.deltaTime;
        }
		player.pMovement.canMove = true;
		isClimbing = false;
		Disable();
    }

	/*void OnCollisionExit(Collision collisionInfo)
	{
		isClimbing = false;
	}

	void OnCollisionStay(Collision collisionInfo)
	{
		if (collisionInfo.gameObject==Player){
			if (Input.GetKey(KeyCode.E))
				isClimbing = true;

			if (Input.anyKeyDown){
				isClimbing = false;
				Debug.Log(isClimbing);
			}

			if (isClimbing)
			{
				VerticalMove = new Vector3(0, Time.deltaTime * VerticalSpeed, 0);
				PlayerRigidbody.AddForce(VerticalMove);
			}
		}
	}*/


}
