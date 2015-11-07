using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Changeover : MonoBehaviour 
{
	public List<Interactable> interactables = new List<Interactable>();
	private GameObject interactableGameObject;

	public int state = 1;
	public int minState = 1;
	public int maxState;

	void Awake()
	{
		//put all interactables in scene into list
		interactableGameObject = GameObject.Find ("Interactables");
		foreach(Transform child in interactableGameObject.transform)
		{
			Interactable interactable = child.GetComponent<Interactable>();
			interactables.Add(interactable);
		}

		//set initial activity
		UpdateInteractables ();
	}

	//Call after Interaction with, or end of conversation -> update objectives bool values
	//If all are true = Changeover
	public virtual void CheckObjective(GameObject gameobject) 
	{

	}

	public void UpdateInteractables()
	{
		for(int i = 0; i<interactables.Count;i++)
		{
			if(interactables[i].activeState == state)
			{
				interactables[i].active = true;
			}
			else
			{
				interactables[i].active = false;
			}
		}
	}
}
