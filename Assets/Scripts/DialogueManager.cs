using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    public string[] dialogLines;
    public int currentLine;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
      
        if (dialogActive && (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space)))
        {
            currentLine++;
            
        }
        if(currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            currentLine = 0;
        }

        dText.text = dialogLines[currentLine];
	}

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
    }
}
