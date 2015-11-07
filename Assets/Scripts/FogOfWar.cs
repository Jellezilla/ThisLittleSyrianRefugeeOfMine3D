using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FogOfWar : MonoBehaviour 
{
	public List<GameObject> fogs = new List<GameObject>();
	public GameObject player;

	private Transform playerTransform;

	private float lowFloor1 = 1;
	private float highFloor1 = 3.8f;
	private float lowFloor2 = 4.2f;
	private float highFloor2 = 8;

	private bool fog1Vis = false;
	private bool fog2Vis = false;

	// Use this for initialization
	void Start () 
	{
		playerTransform = player.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float y = playerTransform.position.y;
		if (y > lowFloor1 && y < highFloor1) 
		{
			fog1Vis = false;
			fog2Vis = true;
			changeFogOfWar();
		}
		else if(y > lowFloor2 && y < highFloor2)
		{
			fog1Vis = true;
			fog2Vis = false;
			changeFogOfWar();
		}
	}

	private void changeFogOfWar()
	{
		if (fog1Vis)
		{
			fogs[0].gameObject.GetComponent<MeshRenderer>().enabled = true;
			fogs[1].gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
		if(fog2Vis)
		{
			fogs[1].gameObject.GetComponent<MeshRenderer>().enabled = true;
			fogs[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
	}
}
