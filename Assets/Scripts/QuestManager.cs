using System.Collections;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestObject[] quests;
    public bool[] questCompleted;
    public DialogueManager theDM;
    public string itemCollected;
    public bool itemColetado = false;

	// Use this for initialization
	void Start ()
    {
        questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ShowQuestText(string questText)
    {
        theDM.dialogLines = new string[1];
        theDM.dialogLines[0] = questText;
        theDM.currentLine = 0;
        theDM.ShowDialogue();
    }
}
