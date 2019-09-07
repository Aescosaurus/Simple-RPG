using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC
	:
	Interactable
{
	public override void Interact()
	{
		DialogueSystem.Instance.AddNewDialogue( myName,dialogue );
		Debug.Log( "Interacting with NPC" );
	}

	public string myName;
	public string[] dialogue;
}
