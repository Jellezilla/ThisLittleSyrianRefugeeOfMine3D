using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    private float speed = 3.5f;
    private Vector3 target;
	private Rigidbody rigid;

    public void SetTarget(Vector3 pos)
    {
        target = pos;
    }

    void Start()
    {
		rigid = transform.GetComponent<Rigidbody> ();
        target = transform.position;
    }

    void Update()
    {
		if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject ()) {
			if (Vector3.Distance (transform.position, new Vector3 (transform.position.x, transform.position.y, 0.0F)) < 0.1F) {
				Debug.Log ("movement call allowed");
				StopAllCoroutines ();
				target = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, transform.position.y, 10.0f));
				target.z = transform.position.z;
			} else {
				Debug.Log ("movement call not allowed");
			}
		} 

    }
    void FixedUpdate()
    {
		/*
		if (Vector3.Distance (transform.position, target) < 0.1F) {
			return;
		}*/
		/*
        Vector3 a = new Vector3(transform.position.x, 0, 0);
        Vector3 b = new Vector3(target.x, 0, 0);

        if (Vector3.Distance(a, b) < 0.5F)
        { 
            target = transform.position;
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }*/
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		//rigid.velocity = (target - transform.position).normalized * speed; 

    }
}
