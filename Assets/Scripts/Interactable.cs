using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable
	:
	MonoBehaviour
{
	public virtual void MoveToInteraction( NavMeshAgent playerAgent )
	{
		hasInteracted = false;

		this.playerAgent = playerAgent;

		playerAgent.stoppingDistance = 3.0f;
		playerAgent.destination = this.transform.position;
	}

	void Update()
	{
		if( !hasInteracted && playerAgent != null &&
			!playerAgent.pathPending )
		{
			if( playerAgent.remainingDistance <=
				playerAgent.stoppingDistance )
			{
				Interact();
				hasInteracted = true;
			}
		}
	}

	public virtual void Interact()
	{
		Debug.Log( "Interacting with base class" );
	}

	[HideInInspector]
	public NavMeshAgent playerAgent;
	bool hasInteracted;
}
