using UnityEngine;
using System.Collections;
/// <summary>
/// This script is an extension of the interactable script. 
/// This specific script handles interaction with containers
/// </summary>
public class Containers : Interactable {

    private Texture2D guiIcon;

	// Use this for initialization
	void Start () {
        SetIcon((Texture2D)Resources.Load("Textures/container_icon"));

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
