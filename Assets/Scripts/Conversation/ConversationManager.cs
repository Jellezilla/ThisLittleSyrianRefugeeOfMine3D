using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

public class ConversationManager : MonoBehaviour 
{
	private GameObject conversationPanel;
	private Image panelImage;

	private GameObject close;
	private Image closeImage;
	private Text closeText;

	public List<GameObject> fields = new List<GameObject>();
	List<string[]> conversations = new List<string[]>();
	List<int[]> indexes = new List<int[]>();

	// Use this for initialization
	void Start () 
	{
		close = GameObject.Find ("Close");
		closeImage = close.GetComponent<Image>();
		Text[] closeArr = close.GetComponentsInChildren<Text>();
		closeText = closeArr[0];

		conversationPanel = GameObject.Find ("ConversationPanel");
		panelImage = conversationPanel.GetComponent<Image>();
	}

	public void InputAnswer(int index)
	{
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

		if(indexes[index].Length == 1)
		{
			closeImage.enabled = true;
			closeText.enabled = true;
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

	public void StartConversation(int conversationID)
	{
		panelImage.enabled = true;

		//set Lists
		SetLists (conversationID);
		InputAnswer (0);
	}

	public void CloseConversation()
	{
		closeImage.enabled = false;
		closeText.enabled = false;
		panelImage.enabled = false;
		Text text = fields[0].GetComponent<Text>();
		text.text = "";
	}

	private void SetLists(int conversationID)
	{
		switch(conversationID)
		{
			case 1:
			{
				FatherSon fatherSon = gameObject.GetComponent<FatherSon>();
				conversations = fatherSon.GetConversationList();
				indexes = fatherSon.GetindexesList();
				break;
			}
			case 2:
			{
				FatherWife fatherWife = gameObject.GetComponent<FatherWife>();
				conversations = fatherWife.GetConversationList();
				indexes = fatherWife.GetindexesList();
				break;
			}
		}
	}
}
