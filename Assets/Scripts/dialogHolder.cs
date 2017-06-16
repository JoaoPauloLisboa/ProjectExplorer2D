using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogHolder : MonoBehaviour
{
    public string dialogue;
    public DialogueManager dMan;
    public string[] dialogueLines;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        onTouchObjeto();
	}
   
    private void onTouchObjeto()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
                // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                if (hitInfo)
                {
                    if (!dMan.dialogActive)
                    {
                        dMan.dialogLines = dialogueLines;
                        dMan.currentLine = 0;
                        dMan.ShowDialogue();
                        
                    }
                    if(dMan.dialogActive)
                    {
                        playerMovement.froze = true;
                    }
                }
            }
        }
    }
}

