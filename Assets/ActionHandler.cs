using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionHandler : MonoBehaviour {
	// jeg prver mig med et nyt kø system af enums!!
	public enum eventStatus{ active, cancled, queued };

	private enum actionType { move, interact };

	private actionType actType;
	private eventStatus evt;

	public Queue actionQueue;

	private bool actionInProgress = false;
	public bool getActionInProgressBool() {
		return actionInProgress;
	}
	public void setActionInProgressBool(bool bolle) {
		actionInProgress = bolle;
	}

	IEnumerator performAction(actionType actType) {
		Debug.Log ("Perform Action method called with type: " + actType.ToString ());
		// switch between two types of action
		if(actType == actionType.interact) {
			// while (actionInProgress)
			while(actionInProgress) {
				yield return null;
			}
		} else if (actType == actionType.move) {
			// while distance is not reached (for moveToPos methods)
			while(true) { //Vector3.Distance(
				yield return null;
			}
		}

	}
	// Use this for initialization
	void Start () {
		actionQueue = new Queue();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			Debug.Log ("a pressed!");
			PerformNextAction();
		}
	if (Input.GetKeyDown (KeyCode.G)) {
			actionQueue.Enqueue("maya venter på mig!");
		}
	}
	private void PerformNextAction() {
		if (actionQueue.Count > 0) {
			Debug.Log (actionQueue.Peek ());
			actionQueue.Dequeue();
		} else {
			Debug.Log("queue is empty!");
		}
	}	
}
