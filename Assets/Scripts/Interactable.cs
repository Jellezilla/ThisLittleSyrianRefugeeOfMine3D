using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



public class Interactable : MonoBehaviour
{
   
    private PlayerMovement pm;

    private Texture2D _guiIcon;

    public Transform interactionPos;
    private Vector3 zlanePos;
    
	private bool xTargetReached = false;

    public void SetIcon(Texture2D icon)
    {
        _guiIcon = icon;
    }

    // Use this for initialization
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    /// <summary>
    /// OnGUI draws the button icon derrived from the classes that inherets this one. 
    /// </summary>
    void OnGUI()
    {
        Vector3 guiPos = Camera.main.WorldToScreenPoint(transform.position);
        
        Rect r = new Rect(guiPos.x, guiPos.y - _guiIcon.height / 2, 50, 50);
        GUI.DrawTexture(r, _guiIcon);
        
        if (GUI.Button(r, "", new GUIStyle()))
        {
            Interact();
        }
        
    }



    /// <summary>
    /// This method is the main method in the interactable script. It can be overwritten by the individual interactable objects. 
    /// It first moves to the interactable object on the x axis, then moves in on the z axis, performs the interaction and afterwards returns to the original z position. 
    /// </summary>
    public virtual void Interact()
    {
        
		Debug.Log ("interact method called");


		// make sure that we have the PlayerMovement script of the player initialized. 
        if (pm == null)
        {
            pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        }

        // test 
        MoveToInteraction(interactionPos.transform.position);

       
    }

    IEnumerator MoveToPos(Vector3 pos)
    {	
		Vector3 targetPos = pos;
		Debug.Log ("moveToPos called");
        if (!xTargetReached) {
			pos = new Vector3 (pos.x, pm.transform.position.y, pm.transform.position.z);
		} else {
			pos = targetPos;
		}
        while (Vector3.Distance(pos, pm.transform.position) > 0.5F)
        {
			Debug.Log ("moveToPos loop");
            pm.SetTarget(pos);
            yield return null;
			xTargetReached = true;
            //GameObject.FindWithTag("Player").GetComponent<Renderer>().material.color = Color.yellow;
        }
        
		Debug.Log ("after loop MoveToPos");
        StartCoroutine(MoveToPos(pos));
		xTargetReached = false;
    }


	/*
    IEnumerator MoveToInteractPos(Vector3 pos)
    {
        while (Vector3.Distance(pos, pm.transform.position) > 0.05F)
        {
            pm.SetTarget(pos);
            yield return null;
        }
		Debug.Log ("out of while loop");
    }*/


    private void MoveToInteraction(Vector3 pos)
    {
        //Vector3 tmpTarget  = new Vector3(pos.x, 0, 0);
        // move to x
        //StartCoroutine(MoveToPos(tmpTarget));
        StartCoroutine(MoveToPos(pos));
        //GameObject.FindWithTag("Player").GetComponent<Renderer>().material.color = Color.green;
        // store pos when done. 
        Vector3 tmpPosition = pm.transform.position;

        // move to z
    //    StartCoroutine(MoveToPos(pos));

        // wait for interation to be done

        // move back to org z
        //  pm.SetTarget(tmpPosition);
    }
}
