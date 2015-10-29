using UnityEngine;
using System.Collections;
/// <summary>
/// This script is an extension of the interactable script. 
/// This specific script is used to interact with stairs.
/// </summary>
public class Stairs : Interactable {
	
	private Texture2D guiIcon;
	Transform stairStartPos;
	public Transform stairEndPos;
	//private PlayerMovement pm;
	// Use this for initialization
	void Start () {
		SetIcon((Texture2D)Resources.Load("Textures/stairs_icon"));
		stairStartPos = interactionPos;
		//pm = GameObject.FindWithTag ("Player").GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (pm != null) {
			if (Vector3.Distance (pm.transform.position, stairEndPos.transform.position) < 1.5) {
				base.StartCoroutine (MoveToZ (new Vector3 (pm.transform.position.x, pm.transform.position.y, 0)));
				ReverseInteractionPositions ();
				base.StopAllCoroutines();
			}
		}
	}
	
	public override void Interact ()
	{
		base.Interact ();
		
		Debug.Log ("stairs");
		base.StartCoroutine(MoveToPos(stairEndPos.transform.position));

		//StartCoroutine (MoveToZ (new Vector3 (pm.transform.position.x, pm.transform.position.y, 0)));
		//ReverseInteractionPositions ();
	}

	
	// reverse stair points 
	
	private void ReverseInteractionPositions ( ) {
		// maybe set gui icon to the position of the interaction position. 
		Transform tmp = stairStartPos;
		stairStartPos = stairEndPos; 
		stairEndPos = tmp; 
		
	}
}
