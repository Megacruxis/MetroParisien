using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour, IButton
{
    [SerializeField] private OpenableManager doorManager;
	[SerializeField] private float InteractRange;

	private bool PlayerIsNear = false;
	private readonly float InputDelay = 0.25f;
	private float Delay = 0f;

   	private bool CanInteract()
	{
		Collider[] colliderArray = Physics.OverlapSphere(transform.position, InteractRange);
		foreach (Collider c in colliderArray)
		{
			if (c.gameObject.tag=="Player")
				return true;
		}
		return false;
	}

	private void Update()
	{
		if (Delay>0){
			Delay -= Time.deltaTime;
		}
		if (!PlayerIsNear)
		{
			PlayerIsNear = CanInteract();
			//Affiche UI
		} 
		else
		{
			if (!CanInteract()){
				PlayerIsNear = false;
				//Retire UI
			}
			if (Input.GetKey(KeyCode.E) && Delay<=0)
			{
				Delay = InputDelay;
				doorManager.InteractWithDoor();
			}
		}
	}
}
