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
        //dMan = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.name == "player")
        {
            if(!dMan.dialogActive)
            {
                print(other.name);
                dMan.dialogLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
                
            }
        }
    }
}

