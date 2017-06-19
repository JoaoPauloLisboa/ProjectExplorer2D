using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogHolder : MonoBehaviour
{
    public string dialogue;
    public DialogueManager dMan;
    public string[] dialogueLines;

    private QuestTrigger theQT;
    private QuestManager theQM;
    public int questNumber;
    public bool startQuest;
    public bool endQuest;

    // Use this for initialization
    void Start ()
    {
        theQM = FindObjectOfType<QuestManager>();
        theQT = FindObjectOfType<QuestTrigger>();
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
                if (hitInfo && hitInfo.collider.name == "NPC-SUSPICIOUS-MAN")
                {
                    if (!theQM.questCompleted[questNumber])
                    {
                        if (startQuest && !theQM.quests[questNumber].gameObject.activeSelf)
                        {
                            theQM.quests[questNumber].gameObject.SetActive(true);
                            theQM.quests[questNumber].StartQuest();
                        }
                        if (theQT.questFinalizada == true && questNumber == 0)
                        {
                            theQM.quests[questNumber].EndQuest();
                            questNumber++;
                        }
                        if (theQM.itemColetado == true && questNumber == 1)
                        {
                            theQM.quests[questNumber].EndQuest();
                        }
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

