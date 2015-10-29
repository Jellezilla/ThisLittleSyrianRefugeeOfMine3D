using UnityEngine;
using System.Collections;
/// <summary>
/// This script is an extension of the interactable script. 
/// This specific script is used to interact with stairs.
/// </summary>
public class Stairs : Interactable {

    private Texture2D guiIcon;
    Transform stairStartPos;
    public Transform stairEndPos;
    // Use this for initialization
    void Start () {
        SetIcon((Texture2D)Resources.Load("Textures/stairs_icon"));
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    // At some point in this logic, it may be needed to switch out the two interactionsPos. 
    /*
        if stair used) {
            
            Transform tmp = stairStartPos;
            stairStartPos = stairEndPos; 
            stairEndPos = tmp;
            */      
}
