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


       /* if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, transform.position.y, 10.0f));
            target.z = transform.position.z;
          
        }
        */
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
