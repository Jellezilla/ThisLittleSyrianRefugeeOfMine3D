using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    /*
        public enum InteractType
        {
            Container, Door, Stair, Enterable
        };
        public InteractType type;
        */
    private PlayerMovement pm;

    private Texture2D _guiIcon;

    public Transform interactionPos;

    public void SetIcon(Texture2D icon)
    {
        _guiIcon = icon;
    }

    // Use this for initialization
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    var guiPosition = Camera.main.WorldToScreenPoint(transform.position);
    guiPosition.y = Screen.height - guiPosition.y;
     var rect = Rect(guiPosition.x - tex.width / 2, guiPosition.y - tex.height / 2.0, tex.width, tex.height);
    GUI.DrawTexture(rect, tex);
 } */

    
    void OnGUI()
    {
        Vector3 guiPos = Camera.main.WorldToScreenPoint(transform.position);
        //guiPos.y = Screen.height - guiPos.y;
        //guiPosition.x - tex.width / 2, guiPosition.y - tex.height / 2.0, tex.width, tex.height);
        //Vector3 guiPos = Camera.main.ScreenToWorldPoint(transform.position);


        //        GUI.DrawTexture(new Rect(guiPos.x-containerIcon.width/2, guiPos.y-containerIcon.height/2, 50, 50), containerIcon);
        Rect r = new Rect(guiPos.x, guiPos.y - _guiIcon.height / 2, 50, 50);
        GUI.DrawTexture(r, _guiIcon);
        
            if (GUI.Button(r, "", new GUIStyle()))
            {
                Interact();
            }
        

        //        GUI.DrawTexture(new Rect(100, 100, 20, 200), stairIcon, ScaleMode.ScaleToFit, true, 10.0f);

        /*      if (type == InteractType.Stair)
              {
                  GUI.DrawTexture(new Rect(transform.position.x - 10, transform.position.y - 10, 20, 20), stairIcon, ScaleMode.ScaleToFit, true, 10.0f);
              } else if(type == InteractType.Container)
              {
                  GUI.DrawTexture(new Rect(transform.position.x - 10, transform.position.y - 10, 20, 20), containerIcon, ScaleMode.ScaleToFit, true, 10.0f);
              }
        */
    }
    public virtual void Interact()
    {
        if(pm != null)
        {
            Vector3 test = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            pm.SetTarget(test);

        } else
        {
            pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            Interact();
        }
        
        //pm.SetTarget(test);
        
    }
}
