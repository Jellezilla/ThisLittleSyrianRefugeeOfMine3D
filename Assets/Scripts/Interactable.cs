using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



public class Interactable : MonoBehaviour
{
    /*
        public enum InteractType
        {
            Container, Door, Stair, Enterable
        };
        public InteractType type;
        */
    private PlayerMovement pm;

    private Texture2D _guiIcon;

    public Transform interactionPos;
    private Vector3 zlanePos;
    


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
        

        //if (Mathf.Abs(interactionPos.transform.position.x) - Mathf.Abs(pm.transform.position.x) < 12.5F)
     /*   if (interactionPos.transform.position.x - pm.transform.position.x < 12.5F)
        {
                pm.SetTarget(interactionPos.transform.position);
                
                // if we have reached the x position update the target
            }
       */ 
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
        // make sure that we have the PlayerMovement script of the player initialized. 
        if (pm == null)
        {
            pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        }

        // test 
        MoveToInteraction(interactionPos.transform.position);

        /*
        // move to x position of interaction
        pm.SetTarget(new Vector3(interactionPos.transform.position.x, pm.transform.position.y, pm.transform.position.z));

        // if the player is at the x position, make him move to the interactionPos on the z axis. 
        
        if(Vector3.Distance(pm.transform.position, transform.position) > 1.0F)
        {
            // do actual interaction
        }

        

        // start the actual interaction (overrideable)     


    */

    }

    IEnumerator MoveToPos(Vector3 pos)
    {
        Vector3 tmpTarget = new Vector3(pos.x, pm.transform.position.y, pm.transform.position.z);
        while (Vector3.Distance(tmpTarget, pm.transform.position) > 0.05F)
        {
            pm.SetTarget(tmpTarget);
            yield return null;
            //GameObject.FindWithTag("Player").GetComponent<Renderer>().material.color = Color.yellow;
        }
        GameObject.FindWithTag("Player").GetComponent<Renderer>().material.color = Color.black;
        //  StartCoroutine(MoveToInteractPos(pos));
    }

    IEnumerator MoveToInteractPos(Vector3 pos)
    {
        while (Vector3.Distance(pos, pm.transform.position) > 0.05F)
        {
            pm.SetTarget(pos);
            yield return null;
        }
    }


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
