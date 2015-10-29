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


    	pos = new Vector3 (pos.x, pm.transform.position.y, pm.transform.position.z);
		Debug.Log ("MoveToX method called");
        while (Vector3.Distance(pos, pm.transform.position) > 0.5F)
        {
			Debug.Log ("moveToPos loop");
            pm.SetTarget(pos);
            yield return null;

        }
		Debug.Log ("Done with first coroutine");
		StartCoroutine (MoveToZ(targetPos));



    }
	IEnumerator MoveToZ(Vector3 pos) {

		Debug.Log ("MoveToZ method called");
		while (Vector3.Distance(pos, pm.transform.position) > 0.1F)
		{
			Debug.Log ("MoveToZ loop");
			Debug.Log ("pos: "+pos.ToString ());
			Debug.Log ("pm: "+pm.transform.position.ToString ());
			pm.SetTarget(pos);
			yield return null;
			
		}
		Debug.Log ("Done with second coroutine");
	}

    private void MoveToInteraction(Vector3 pos)
    {
      
        StartCoroutine(MoveToPos(pos));
      


    }
}
