﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem
	:
	MonoBehaviour
{
	void Awake()
	{
		continueButton = dialoguePanel.transform.Find(
			"Continue" ).GetComponent<Button>();

		dialogueText = dialoguePanel.transform.Find(
			"Text" ).GetComponent<Text>();
		nameText = dialoguePanel.transform.Find(
			"Name" ).GetChild( 0 ).GetComponent<Text>();

		continueButton.onClick.AddListener( delegate
		{
			ContinueDialogue();
		} );

		dialoguePanel.SetActive( false );

		if( Instance != null && Instance != this )
		{
			Destroy( gameObject );
		}
		else
		{
			Instance = this;
		}
	}

	public void AddNewDialogue( string npcName,string[] lines )
	{
		dialogueIndex = 0;
		this.npcName = npcName;
		dialogueLines = new List<string>( lines.Length );
		dialogueLines.AddRange( lines );

		Debug.Log( dialogueLines.Count );
		CreateDialogue();
	}

	public void CreateDialogue()
	{
		nameText.text = npcName;
		dialogueText.text = dialogueLines[dialogueIndex];
		dialoguePanel.SetActive( true );
	}

	public void ContinueDialogue()
	{
		if( dialogueIndex < dialogueLines.Count - 1 )
		{
			++dialogueIndex;
			dialogueText.text = dialogueLines[dialogueIndex];
		}
		else
		{
			dialoguePanel.SetActive( false );
		}
	}

	public static DialogueSystem Instance { get; set; }

	public GameObject dialoguePanel;
	string npcName;
	List<string> dialogueLines = new List<string>();

	Button continueButton;
	Text nameText;
	Text dialogueText;
	int dialogueIndex;
}
