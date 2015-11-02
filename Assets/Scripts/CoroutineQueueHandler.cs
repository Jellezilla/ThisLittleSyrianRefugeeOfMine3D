using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoroutineQueueHandler : MonoBehaviour {


	private enum state { cancled, active, queued };
	Queue coroutineQueue = new Queue();

	

	void CallStoredRoutine(int index)
	{
		// coroutineQueue.Peek() inspect
		// coroutineQueue.count() 

	//	StartCoroutine(coroutineQueue.Dequeue());
	}

	// Use this for initialization
	void Start () {
		coroutineQueue.Enqueue ("");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
