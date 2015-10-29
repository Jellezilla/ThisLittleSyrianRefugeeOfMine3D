using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{


    
    private float speed = 3.5f;
    private Vector3 target;


    public void SetTarget(Vector3 pos)
    {
        target = pos;
    }

    void Start()
    {
        target = transform.position;
       
    }

    void Update()
    {

/*
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, transform.position.y, 10.0f));
            target.z = transform.position.z;
          
        }
  */      
       
    }
    void FixedUpdate()
    {
        Vector3 a = new Vector3(transform.position.x, 0, 0);
        Vector3 b = new Vector3(target.x, 0, 0);

        if (Vector3.Distance(a, b) < 0.5F)
        { 
            target = transform.position;
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}
