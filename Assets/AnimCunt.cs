using UnityEngine;
using System.Collections;

public class AnimCunt : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			anim.SetInteger("direction", 1);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			anim.SetInteger ("direction", 3);
		}
		anim.SetFloat ("speed", 1.0F);
	}
}
