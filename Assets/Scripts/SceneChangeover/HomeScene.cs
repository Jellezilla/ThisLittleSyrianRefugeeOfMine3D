using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HomeScene : Changeover 
{
	//changeover to 2
	private int conversationIDToComplete = 1;
	private bool conversationObjective = false;

	void Start()
	{
		maxState = 2;
	}

	public override void CheckObjective(GameObject gameobject) 
	{
		if (gameobject.GetComponent<Conversation> () != null && gameobject.GetComponent<Conversation>().conversationId == conversationIDToComplete) 
		{
			CheckChangeover();
		}
	}

	private void CheckChangeover()
	{
		if(state == 1)
		{
			if(conversationObjective) //chain objective
			{
				state++;
			}
		}
	}
}
