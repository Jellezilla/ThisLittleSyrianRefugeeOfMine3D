using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This script is an extension of the interactable script. 
/// This specific script is used to interact with stairs.
/// </summary>
public class Stairs : Interactable {
	
	private Texture2D guiIcon;
	Transform stairStartPos;
	public Transform stairEndPos;


	void Start () {
		SetIcon((Texture2D)Resources.Load("Textures/stairs_icon"));
		stairStartPos = interactionPos;
		ReverseInteractionPositions ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public override void Interact ()
	{
		base.Interact ();
		
		Debug.Log ("stairs");

		StartCoroutine (CoroutineCalls ());
	}

	/// <summary>
	/// Reverses the interaction positions.
	/// </summary>
	private void ReverseInteractionPositions ( ) {
		// maybe set gui icon to the position of the interaction position. 
		Debug.Log ("reverse interactions position called");
		Transform tmp = stairStartPos;
		stairStartPos = stairEndPos; 
		stairEndPos = tmp;

		base.interactionPos = stairStartPos;
		
	}

	public IEnumerator CoroutineCalls()
	{
		Vector3 xPos = new Vector3 (stairStartPos.transform.position.x, pm.transform.position.y, 0.0F);  // find x position

		yield return StartCoroutine(MoveToPos(xPos)); 													// move to x position
		yield return StartCoroutine(MoveToPos(stairStartPos.transform.position));						// move to interaction position
		yield return StartCoroutine(MoveToPos(stairEndPos.transform.position));							// move up the stairs *specific for this one*
		//yield return StartCoroutine(FourthColorCoroutine()); interact									// while interaction *not used for the stairs*
		yield return StartCoroutine (MoveToPos (new Vector3(stairEndPos.transform.position.x, pm.transform.position.y, 0.0F))); // move back to the x position *alternative position for the stairs*
        ReverseInteractionPositions();		                 
	}

	public IEnumerator MoveToPos(Vector3 pos) 
	{
		pm.SetTarget	(pos);
		while (Vector3.Distance(pos, pm.transform.position) > 1.25F)
		{
			yield return null;
		}
	}
}
