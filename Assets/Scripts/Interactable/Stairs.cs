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
	public delegate void QueueMethod();

	Queue<QueueMethod> testQ;

	//private PlayerMovement pm;
	// Use this for initialization
	void Start () {
		SetIcon((Texture2D)Resources.Load("Textures/stairs_icon"));
		stairStartPos = interactionPos;
		//pm = GameObject.FindWithTag ("Player").GetComponent<PlayerMovement> ();
//		ah = base.ah;
		testQ = new Queue<QueueMethod>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.U)) {
			Debug.Log (testQ.Peek().ToString());
			QueueMethod callback = testQ.Dequeue();
			callback();
		}
	}
	
	public override void Interact ()
	{
		base.Interact ();
		
		Debug.Log ("stairs");

	}

	public override void AddElementsToQueue ()
	{
		Debug.Log ("add elements to queue @ stairs.cs");

	//	base.ah.actionQueue.Enqueue (StartCoroutine (MoveToPos (stairStartPos.transform.position)));
//		base.ah.actionQueue.Enqueue (StartCoroutine (base.MoveToPos (stairEndPos.transform.position)));
//		base.ah.actionQueue.Enqueue (StartCoroutine (base.MoveToPos (new Vector3 (stairEndPos.transform.position.x, 0.0F, 0.0F))));
		//ReverseInteractionPositions ();
		testQ.Enqueue (TestMethod);
		base.AddElementsToQueue ();


	}

	void TestMethod(){
		StartCoroutine (TestCoroutine ());
	}

	IEnumerator TestCoroutine() {

		Debug.Log ("testMethod called!");
		yield return new WaitForSeconds (3);
		Debug.Log ("test method post wait");
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
}
