using UnityEngine;
using System.Collections;
/// <summary>
/// This script is an extension of the interactable script. 
/// This specific script is used to handle conversation with NPCs.
/// </summary>
public class Conversation : Interactable {
   

	// Use this for initialization
	void Start () {
        SetIcon((Texture2D)Resources.Load("Textures/conversation_icon"));
    }
	    
	// Update is called once per frame
	void Update () {
	
	}
}
