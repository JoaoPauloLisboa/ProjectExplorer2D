using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public int questNumber;
    public QuestManager theQM;
    public string startText;
    public string endText;
    public bool isItemQuest;
    public string targetItem;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isItemQuest)
        {
            if(theQM.itemCollected == targetItem)
            {
                theQM.itemCollected = null;
                EndQuest3();
            }
        }
	}

    public void StartQuest()
    {
        theQM.ShowQuestText(startText);
    }

    public void EndQuest()
    {
        theQM.ShowQuestText(endText);
        theQM.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }
    public void EndQuest2()
    {
        theQM.ShowQuestText("Voce encontrou o Cristo Redentor, retire o zoom caso deseje ve-lo! Retorne ao NPC para recolher sua recompensa.");
    }
    public void EndQuest3()
    {
        theQM.ShowQuestText("Voce encontrou o celular, retorne ao NPC para recolher sua recompensa.");
    }
}
