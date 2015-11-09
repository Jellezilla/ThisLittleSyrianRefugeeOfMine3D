using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoroutineQueueHandler : MonoBehaviour {
	
	delegate void MyDelegate(Vector3 pos);
	MyDelegate myDelegate;

	Queue<MyDelegate> testQ;
	
	PlayerMovement pm;
	
	// Use this for initialization
	void Start () {
/*		testVec = new Vector3(6.0F, 6.0F, 6.0F);
		testQ = new Queue<MyDelegate>();
		myDelegate = MoveTo;
		myDelegate(new Vector3(10.0F, 1.2F, 0.0F));
*/	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Y)) {
			Debug.Log ("Y pressed!");
//			testQ.Enqueue (() => myDelegate(new Vector3(5.0F, 1.2F, 0.0F)));  		//ActionQueue.Enqueue(MoveToInteraction, target);
			
			//testQ.Enqueue(myDelegate(new Vector3(5.0F, 1.2F, 0.0F)));
		}
		if(Input.GetKeyDown(KeyCode.N)) {
			MyDelegate callback = testQ.Dequeue();
			callback(Vector3.zero);
		}
		if(Input.GetKeyDown(KeyCode.B)) {
			myDelegate(new Vector3(5.0F, 4.0F, 3.0F));
		}
		if(Input.GetKeyDown(KeyCode.M)) {
			if(testQ.Count > 0) {
				Debug.Log (testQ.Peek().ToString ());
				testQ.Dequeue();
			}
		}
		
	}
	
	private void MoveTo(Vector3 target)
	{
		/*pm = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
		pm.SetTarget(target);
		Debug.Log ("target should be set by now!");
		Debug.Log (target.ToString());*/
		StartCoroutine(waitMethod (target));
	}
	
	IEnumerator waitMethod(Vector3 target) {
		Debug.Log ("pre wait");
		yield return new WaitForSeconds(2);
		Debug.Log("post wait. Target: "+target);
	}
}
