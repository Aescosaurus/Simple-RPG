using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction
	:
	MonoBehaviour
{
	void Start()
	{
		playerAgent = GetComponent<NavMeshAgent>();
	}

	// Check for mouse input.
	void Update()
	{
		if( Input.GetMouseButtonDown( 0 ) &&
			!UnityEngine.EventSystems.EventSystem
			.current.IsPointerOverGameObject() )
		{
			GetInteraction();
		}
	}

	// Handles checking what we're interacting with.
	// Grab cam, send ray, do stuff with ray info.
	void GetInteraction()
	{
		Ray interactionRay = Camera.main.ScreenPointToRay(
			Input.mousePosition );
		RaycastHit interactionInfo;

		if( Physics.Raycast( interactionRay,
			out interactionInfo,Mathf.Infinity ) )
		{
			GameObject interactedObject = interactionInfo
				.collider.gameObject;

			if( interactedObject.tag ==
				"Interactable Object" )
			{
				interactedObject.GetComponent<Interactable>()
					.MoveToInteraction( playerAgent );
			}
			else
			{
				playerAgent.stoppingDistance = 0.0f;
				playerAgent.destination = interactionInfo
					.point;
			}
		}
	}

	NavMeshAgent playerAgent;
}
