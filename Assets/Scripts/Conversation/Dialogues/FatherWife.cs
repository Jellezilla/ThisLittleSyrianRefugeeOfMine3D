using UnityEngine;
using System.Collections;

public class FatherWife : Dialogue 
{

	// Use this for initialization
	void Start () 
	{
		//set values maually here
		string[] schema = {"FatherWife", "Answer1", "Answer2", "Answer3"}; //index, comment
		int[] schemaIndexes = {0,1,1,3}; //start with 0, then link to conversation array
		
		string[] text1 = {"Test", "answerA", "AnswerB"}; //1
		int[] text1Indexes = {0,2,3};
		
		string[] text2 = {"aaaaaaaaa", "bbb", "ccc", "ddd", "eee"}; //2
		int[] text2Indexes = {0,3,3,3,3};
		
		string[] text3 = {"end of conversation"}; //3
		int[] text3Indexes = {0}; //end of conversation
		
		//add conversations strings
		conversations.Add (schema);
		conversations.Add (text1);
		conversations.Add (text2);
		conversations.Add (text3);
		
		//add conversation indexes
		indexes.Add (schemaIndexes);
		indexes.Add (text1Indexes);
		indexes.Add (text2Indexes);
		indexes.Add (text3Indexes);
	}
}
