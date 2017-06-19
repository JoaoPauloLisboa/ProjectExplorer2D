using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    private QuestManager theQM;
    public int questNumber;
    public bool startQuest;
    public bool endQuest;
    public bool questFinalizada = false;
    public int entreiUma = 0;

	// Use this for initialization
	void Start ()
    {
        theQM = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "player")
        {
            if (!theQM.questCompleted[questNumber])
            {               
                if(endQuest && theQM.quests[questNumber].gameObject.activeSelf && entreiUma == 0)
                {
                    questFinalizada = true;
                    theQM.quests[questNumber].EndQuest2();
                    entreiUma++;
                }
            }
        }
    }
}
