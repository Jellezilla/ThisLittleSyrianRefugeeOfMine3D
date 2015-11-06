using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



public class Interactable : MonoBehaviour
{
	
	public PlayerMovement pm;
	public ActionHandler ah;
	private Texture2D _guiIcon;
	
	public Transform interactionPos;


	public void SetIcon(Texture2D icon)
	{
		_guiIcon = icon;
	}


	// Use this for initialization
	void Start()
	{
		ah = GameObject.FindGameObjectWithTag("ActionHandler").GetComponent<ActionHandler> ();
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
		Vector3 guiPos = Camera.main.WorldToScreenPoint(transform.position);
		
		Rect r = new Rect(guiPos.x, guiPos.y - _guiIcon.height / 2, 50, 50);
		GUI.DrawTexture(r, _guiIcon);
		
		if (GUI.Button(r, "", new GUIStyle()))
		{
			MoveToInteraction (interactionPos.transform.position);
			//ah.actionQueue.Enqueue (
		}
	}
	

	/// <summary>
	/// This method is the main method in the interactable script. It can be overwritten by the individual interactable objects. 
	/// It first moves to the interactable object on the x axis, then moves in on the z axis, performs the interaction and afterwards returns to the original z position. 
	/// </summary>
	public virtual void Interact()
	{
		Debug.Log ("interact method called");
		
	}

	IEnumerator MoveToX(Vector3 pos)
	{	
		Vector3 targetPos = pos;
		
		pos = new Vector3 (pos.x, pm.transform.position.y, pm.transform.position.z);
		Debug.Log ("MoveToX method called");
		pm.SetTarget(pos);
		while (Vector3.Distance(pos, pm.transform.position) > 0.5F)
		{
			yield return null;
		}
		Debug.Log ("Done with first coroutine");

		StartCoroutine (MoveToZ(targetPos));
		
	}

	public IEnumerator MoveToZ(Vector3 pos) {
		
		Debug.Log ("MoveToZ method called");
		
		pm.SetTarget(pos);
		while (Vector3.Distance(pos, pm.transform.position) > 1.5F)
		{
			yield return null;
		}

		Debug.Log ("Done with second coroutine");
		Interact();
		yield return true;
	}

	public IEnumerator MoveToPos(Vector3 pos) {
		
		Debug.Log ("MoveToPos method called");
		
		pm.SetTarget	(pos);
		while (Vector3.Distance(pos, pm.transform.position) > 1.5F)
		{
			yield return null;
		}
		Debug.Log ("Done with moveToPos method");
	}

	private void MoveToInteraction(Vector3 pos)
	{
		// make sure that we have the PlayerMovement script of the player initialized. 
		if (pm == null)
		{
			pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		}
		if (ah == null) {
			Debug.Log ("I should be populating the ah var!");
			ah = GameObject.FindGameObjectWithTag("ActionHandler").GetComponent<ActionHandler>();
		}
		//StartCoroutine(MoveToX(pos));
		AddElementsToQueue ();
	}

	//-------------

	public virtual void AddElementsToQueue() {
		Debug.Log ("base AddElementsToQueue method called");
	}


}
