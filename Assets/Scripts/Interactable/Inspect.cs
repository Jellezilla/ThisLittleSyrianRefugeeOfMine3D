using UnityEngine;
using System.Collections;

/// <summary>
/// This script is an extension of the interactable script. 
/// This class is used to read/view texts objects/pictures found througout the game. 
/// </summary>
public class Inspect : Interactable {
	
	private Texture2D guiIcon; 
	public Transform inspectObject;
	// Use this for initialization
	void Start () {
		SetIcon((Texture2D)Resources.Load("Textures/inspect_icon"));
	}
	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.K)) {
			isInteractionActive = false;

		}
	}
	public override void Interact ()
	{
		base.Interact ();
		StartCoroutine (CoroutineCalls ());
	}
	
	public IEnumerator CoroutineCalls()
	{
		Vector3 xPos = new Vector3 (interactionPos.transform.position.x, pm.transform.position.y, 0.0F); 			// find x position

		
		yield return StartCoroutine(MoveToPos(xPos));																// move to x position
		yield return StartCoroutine(MoveToPos(interactionPos.transform.position));									// move to interaction position
		yield return StartCoroutine(WaitForInteraction()); 														// while interacting
		yield return StartCoroutine(MoveToPos(new Vector3(pm.transform.position.x, pm.transform.position.y, 0.0F)));
		
	}
	
	public IEnumerator MoveToPos(Vector3 pos) {
		pm.SetTarget	(pos);
		while (Vector3.Distance(pos, pm.transform.position) > 1.5F)
		{
			yield return null;
		}
	}
	
	
	private IEnumerator WaitForInteraction() 
	{
		isInteractionActive = true;

		// instantiate inspect object
		GameObject tmp = Instantiate (inspectObject, new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y - 1, -4.3F), Quaternion.identity) as GameObject;
		while (isInteractionActive) {

			Debug.Log ("Interaction is active!");
			yield return null;
		}
		Debug.Log ("destroy inspect please!");
		// destroy instantiated object
		Destroy (GameObject.FindWithTag ("Inspect"));
	}

	

	
}
