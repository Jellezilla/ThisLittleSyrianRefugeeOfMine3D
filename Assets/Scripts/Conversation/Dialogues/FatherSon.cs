using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FatherSon : Dialogue
{
	// Use this for initialization
	void Start () 
	{
		//set values maually here
		string[] schema = {"Dad... where is Imaan?", "I don't know how to tell you this... but Imaan is dead, she died yesterday at her school.", "Imaan have traveled to our new home, she awaits us there.", "She is with Aman, and she is going to travel with them.", "She has gone to heaven with grandma and grandpa.", "Don't worry about Imaan right now."}; //index, comment
		int[] schemaIndexes = {0,1,2,3,4,5};
		
		string[] text1 = {"What... what do you mean... is she not coming home?", "Imaan is never coming back Awad, she... died yesterday. They haven't found her body, but we need to leave the city now...", "We lost her... so many have we lost... /cry", "We have no time to talk about it now Awad, I'll explain it later."}; //1
		int[] text1Indexes = {0,6,6,6}; //leads to nowhere, but has answers
		
		string[] text2 = {"Where are we going dad? and why?", "We need to get away from Syria, away from the bad men that are here... we are going to Sweden...", "We are not safe here any more, we need to get to somewhere safe...", "I don't know where we are going, but we can't stay here..."}; //2
		int[] text2Indexes = {0,6,6,6}; //leads to nowhere, but has 3 answers
		
		string[] text3 = {"Travel? are we going somewhere?", "I don't know where we are going, but we can't stay here...", "empty", "empty"}; //3
		int[] text3Indexes = {0,6,6,6}; //leads to nowhere, but has 3 answers

		string[] text4 = {"How?", "I don't know how to tell you this... but Imaan is dead, she died yesterday at her school."}; //4
		int[] text4Indexes = {0,1};

		string[] text5 = {"Why? Imaan promised to read for me...?", "empty", "empty", "empty"}; //5
		int[] text5Indexes = {0,6,6,6}; //leads to nowhere, but has 3 answers

		string[] text6 = {"Click Close..."}; //5
		int[] text6Indexes = {0};
		
		//add conversations strings
		conversations.Add (schema);
		conversations.Add (text1);
		conversations.Add (text2);
		conversations.Add (text3);
		conversations.Add (text4);
		conversations.Add (text5);
		conversations.Add (text6);
		
		//add conversation indexes
		indexes.Add (schemaIndexes);
		indexes.Add (text1Indexes);
		indexes.Add (text2Indexes);
		indexes.Add (text3Indexes);
		indexes.Add (text4Indexes);
		indexes.Add (text5Indexes);
		indexes.Add (text6Indexes);
	}
}
