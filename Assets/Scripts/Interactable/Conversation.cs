using UnityEngine;
using System.Collections;
/// <summary>
/// This script is an extension of the interactable script. 
/// This specific script is used to handle conversation with NPCs.
/// </summary>
public class Conversation : Interactable 
{
	private GameObject conversationManagement;
	private ConversationManager conversationManager;
	public int conversationId;
	
	// Use this for initialization
	void Start () 
	{
        SetIcon((Texture2D)Resources.Load("Textures/conversation_icon"));
    	
		conversationManagement = GameObject.Find ("ConversationManagement");
		conversationManager = conversationManagement.GetComponent<ConversationManager>();
	}
	    
	public override void Interact ()
	{
		conversationManager.StartConversation (conversationId);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
