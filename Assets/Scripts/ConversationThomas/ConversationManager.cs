using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

public class ConversationManager : MonoBehaviour 
{
	private GameObject conversationPanel;
	private Image panelImage;

	public List<GameObject> fields = new List<GameObject>();
	List<string[]> conversations = new List<string[]>();
	List<int[]> indexes = new List<int[]>();

	// Use this for initialization
	void Start () 
	{
		conversationPanel = GameObject.Find ("ConversationPanel");
		panelImage = conversationPanel.GetComponent<Image>();

		string[] schema = {"text to react to", "Answer1", "Answer2", "Answer3"}; //index, comment
		int[] schemaIndexes = {0,0,0,0}; //start with 0, then link to conversation array

		string[] text1 = {"Test", "answerA", "AnswerB"}; //1
		int[] text1Indexes = {0,2,3};

		string[] text2 = {"aaa", "bbb", "ccc", "ddd", "eee"}; //2
		int[] text2Indexes = {0,2,3,3,3};

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

	public void InputAnswer(int index)
	{
		panelImage.enabled = true;
		UnloadPanel ();

		Text text = fields[0].GetComponent<Text>();
		text.text = conversations [index] [0];

		for(int i = 1; i < conversations[index].Length; i++)
		{
			Button button = fields[i].GetComponent<Button>();
			Text[] answerArr = button.GetComponentsInChildren<Text>();
			Text answer = answerArr[0];
			answer.enabled = true;
			answer.text = conversations [index] [i];
			int newIndex = indexes[index][i];
			button.onClick.AddListener(
				delegate
				{
					InputAnswer(newIndex);
				}
			);
		}
	}

	private void UnloadPanel()
	{
		for (int i = 1; i < fields.Count; i++) 
		{
			Text[] textArr = fields[i].GetComponentsInChildren<Text>();
			textArr[0].enabled = false;
		}
	}
}
