using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



public class Interactable : MonoBehaviour
{
	
	public PlayerMovement pm;

	private Texture2D _guiIcon;
	
	public Transform interactionPos;
	public bool isInteractionActive = false;


	public void SetIcon(Texture2D icon) {
		_guiIcon = icon;
	}


	// Use this for initialization
	void Start()
	{
		pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	
	
	/// <summary>
	/// OnGUI draws the button icon derrived from the classes that inherets this one. 
	/// </summary>
	void OnGUI()
	{
		/*
		var guiPosition = Camera.main.WorldToScreenPoint(transform.position);
		guiPosition.y = Screen.height - guiPosition.y;
		var rect = Rect(guiPosition.x - tex.width/2, guiPosition.y - tex.height/2.0, tex.width, tex.height);
		GUI.DrawTexture(rect, tex);
		*/
		Vector3 guiPos = Camera.main.WorldToScreenPoint (interactionPos.transform.position); // transform.position);
		
		Rect r = new Rect(guiPos.x, Screen.height-guiPos.y, 50, 50);
		GUI.DrawTexture(r, _guiIcon);
		
		if (GUI.Button(r, "", new GUIStyle()))
		{
			Interact ();
		}

		if (isInteractionActive) {
			if(GUI.Button(new Rect(Screen.width-300, Screen.height-200, 150, 50), "Close Interaction")) {
				isInteractionActive = false;
			}
		}
	}
	

	/// <summary>
	/// This method is the main method in the interactable script. It can be overwritten by the individual interactable objects. 
	/// It first moves to the interactable object on the x axis, then moves in on the z axis, performs the interaction and afterwards returns to the original z position. 
	/// </summary>
	public virtual void Interact()
	{
		if (pm == null)
			pm = GameObject.FindWithTag ("Player").GetComponent<PlayerMovement> ();

		Debug.Log ("interact method called");
	}

}
