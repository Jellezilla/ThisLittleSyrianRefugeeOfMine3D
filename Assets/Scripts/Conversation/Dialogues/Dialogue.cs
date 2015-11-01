using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour 
{
	public List<string[]> conversations = new List<string[]>();
	public List<int[]> indexes = new List<int[]>();

	public List<string[]> GetConversationList()
	{
		return conversations;
	}
	
	public List<int[]> GetindexesList()
	{
		return indexes;
	}
}
