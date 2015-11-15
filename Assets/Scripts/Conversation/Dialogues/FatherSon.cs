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
		
		string[] text1 = {"What... what do you mean... is she not coming home?", "Imaan is never coming back Awad, she... died yesterday. They haven't found her body, but we need to leave the city now...", "We lost her... we have lost so many these last days... *cry*", "We have no time to talk about it now Awad, I'll explain it later."}; //1
		int[] text1Indexes = {0,7,9,12};
		
		string[] text2 = {"Where are we going dad? and why?", "We need to get away from Syria, away from the bad men that are here... we are going to Sweden...", "We are not safe here any more, we need to get to somewhere safe...", "I don't know where we are going, but we can't stay here..."}; //2
		int[] text2Indexes = {0,13,14,15};
		
		string[] text3 = {"Travel? are we going somewhere?", "I don't know where we are going, but we can't stay here...", "Yes we are going on a journey, hopefully we can find a new life in Sweden", "We are going away from Syria for good Awad, the country have changed... we are no longer safe. We can hopefully find refuge in Europe... hopefully"}; //3
		int[] text3Indexes = {0,15,13,16};

		string[] text4 = {"How?", "I don't know how to tell you this... but Imaan is dead, she died yesterday at her school."}; //4
		int[] text4Indexes = {0,1};

		string[] text5 = {"Why? Imaan promised to read for me...?", "I will read to you now Awad...", "Imaan gone, she will never read for you again Awad... ", "I know that it is hard to accept Awad, but I really need you to go pack your things. We are going away."}; //5
		int[] text5Indexes = {0,17,18,6}; //leads to nowhere, but has 3 answers

		string[] text6 = {"Click Close..."}; //6
		int[] text6Indexes = {0};

		string[] text7 = {"Dead........ But... I talked with her yesterday... *sob* am I going to die too dad?", "Not as long as I'm here to protect you, I promise I will keep you safe. Now prepare yourself, we'll leave soon.", "We all die one day son, but you won't die for a long time"}; //7
		int[] text7Indexes = {0,8,11};

		string[] text8 = {"...*smiles*"}; //8
		int[] text8Indexes = {0};

		string[] text9 = {"We can just go find her... right?", "Imaan is never coming back Awad, she... died yesterday. They haven't found her body, but we need to leave the city now...", "If we go to find her body, we might also die Awad... I will not... cannot risk that..."}; //9
		int[] text9Indexes = {0,8,10};

		string[] text10 = {"But... I don't want to die... *sobs and turns away with tears in his eyes*"}; //10
		int[] text10Indexes = {0};

		string[] text11 = {"Okay dad... *bows head saddened*"}; //11
		int[] text11Indexes = {0};

		string[] text12 = {"But... I don't understand... I want to know...", "No Awad! We don't have time right now... it will have to wait!", "I know you want to understand, and that is good my son... but we don't have time for me to explain now."}; //12
		int[] text12Indexes = {0,18,19};

		string[] text13 = {"Sweden? What is Sweden?", "It is a place without war, I will tell you more once we are gone from this place", "Sweden is a country far away from the here, away from the war... a place for us to be safe"}; //13
		int[] text13Indexes = {0,19,20};

		string[] text14 = {"Why are we not safe...? I do not understand...", "I don't need you to understand right now Awad, I need you to listen to me. Go get ready to leave, ask you mother for help"}; //14
		int[] text14Indexes = {0,11};

		string[] text15 = {"But I want to stay and play soccer with Ahmed", "Awad! Stop being silly, we need to leave now... it is no time to talk about socccer!", "I know you want to, but sadly you can't, I promise I'll buy you a new ball and boots when we come to Sweden"}; //15
		int[] text15Indexes = {0,11,21};

		string[] text16 = {"But... I don't know anyone in Europe, all my friends are here...", "Come on Awad, you will get so many new friends in Sweden, and maybe some of your friends will be there too", "I know it is a lot to leave behind, but you are going to meet new kids on our journey... maybe make new friends... we all leave something behind"}; //16
		int[] text16Indexes = {0,19,11};

		string[] text17 = {"But you can't make the voices...", "I can make other voices, but we really don't have time for this know... We need to leave"}; //17
		int[] text17Indexes = {0,2};

		string[] text18 = {"*starts crying and stops talking*"}; //18
		int[] text18Indexes = {0};

		string[] text19 = {"Okay... *stop and looks at you, before turning away*"}; //19
		int[] text19Indexes = {0};

		string[] text20 = {"I still don't understand... who are these bad men..."}; //20
		int[] text20Indexes = {0};

		string[] text21 = {"Really!! *smiles thrilled and turns away*"}; //21
		int[] text21Indexes = {0};

		//add conversations strings
		conversations.Add (schema);
		conversations.Add (text1);
		conversations.Add (text2);
		conversations.Add (text3);
		conversations.Add (text4);
		conversations.Add (text5);
		conversations.Add (text6);
		conversations.Add (text7);
		conversations.Add (text8);
		conversations.Add (text9);
		conversations.Add (text10);
		conversations.Add (text11);
		conversations.Add (text12);
		conversations.Add (text13);
		conversations.Add (text14);
		conversations.Add (text15);
		conversations.Add (text16);
		conversations.Add (text17);
		conversations.Add (text18);
		conversations.Add (text19);
		conversations.Add (text20);
		conversations.Add (text21);

		//add conversation indexes
		indexes.Add (schemaIndexes);
		indexes.Add (text1Indexes);
		indexes.Add (text2Indexes);
		indexes.Add (text3Indexes);
		indexes.Add (text4Indexes);
		indexes.Add (text5Indexes);
		indexes.Add (text6Indexes);
		indexes.Add (text7Indexes);
		indexes.Add (text8Indexes);
		indexes.Add (text9Indexes);
		indexes.Add (text10Indexes);
		indexes.Add (text11Indexes);
		indexes.Add (text12Indexes);
		indexes.Add (text13Indexes);
		indexes.Add (text14Indexes);
		indexes.Add (text15Indexes);
		indexes.Add (text16Indexes);
		indexes.Add (text17Indexes);
		indexes.Add (text18Indexes);
		indexes.Add (text19Indexes);
		indexes.Add (text20Indexes);
		indexes.Add (text21Indexes);
	}
}
