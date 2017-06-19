using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public int questNumber;
    private QuestManager theQM;
    public string itemName;

	// Use this for initialization
	void Start ()
    {
        theQM = FindObjectOfType<QuestManager>();		
	}
	
	// Update is called once per frame
	void Update ()
    {
        onTouchObjeto();
	}
    /*
    private void OnTriggerEnter(Collider2D other)
    {
        if(other.gameObject.name == "player")
        {
            if(!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf)
            {
                
            }
        }
    }
    */
    private void onTouchObjeto()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
                // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                if (hitInfo && hitInfo.collider.name == "celQuest")
                {
                    theQM.quests[questNumber].EndQuest3();
                    theQM.itemCollected = itemName;
                    theQM.itemColetado = true;
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
