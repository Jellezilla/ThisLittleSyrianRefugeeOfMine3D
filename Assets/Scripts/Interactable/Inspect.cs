using UnityEngine;
using System.Collections;
/// <summary>
/// This script is an extension of the interactable script. 
/// This class is used to read/view texts objects/pictures found througout the game. 
/// </summary>
public class Inspect : Interactable {

    private Texture2D guiIcon; 
	// Use this for initialization
	void Start () {
        SetIcon((Texture2D)Resources.Load("Textures/inspect_icon"));
    }
	

	// Update is called once per frame
	void Update () {
	
	}
}
