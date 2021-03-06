﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour 
{
	ConversationManager manager;

	// Use this for initialization
	void Start () 
	{
		manager = gameObject.GetComponent<ConversationManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void WriteText(string text, Text field)
	{
		string writtenText = "";
		field.text = writtenText;
		int index = 0;
		//field.text = text;
		//manager.DoneTyping ();
		StartCoroutine (WriteLetter (text, field, index, writtenText));
	}

	IEnumerator WriteLetter(string text, Text field, int index, string writtenText)
	{
		yield return new WaitForSeconds(0.003f);
		writtenText += text[index];
		field.text = writtenText;
		index++;
		if (index < text.Length) 
		{
			//Debug.Log ("continue with index = " + index);
			StartCoroutine (WriteLetter (text, field, index, writtenText));
		}
		if(index == text.Length-1) //done typing -> callback
		{
			Debug.Log("done with typing");
			manager.DoneTyping();
		}
	}
}
