using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost
	:
	ActionItem
{
	public override void Interact()
	{
		DialogueSystem.Instance.AddNewDialogue(
			"Sign",dialogue );

		Debug.Log( "Interacting with sign post" );
	}

	public string[] dialogue;
}
