using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int MonsterFight = 0;

    [SerializeField]
    private FirstLevelPictureStory loadManager;

    List<Decisions> decisionList = new List<Decisions>();

	// Use this for initialization
	void Start ()
    {
        loadManager = GetComponent<FirstLevelPictureStory>();
        loadManager.StartGameStory();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void IsGoodDecision(bool isGood)
    {
        MonsterFight += 1;
        if (isGood)
        {
            decisionList[MonsterFight].RightDecision += 1;
        }
        else
        {
            decisionList[MonsterFight].WrongDecision += 1;
        }
    }

    public void DecisionSummary()
    {
        foreach (var item in decisionList)
        {
            if (item.WrongDecision > 0)
            {
                // TODO Trigger Worng Deciison
                break;
            }
            else
            {
                // TODO Trigger Right Decision
                break;
            }
        }
    }


    private void TriggerWrongEnd()
    {
        // TODO Here some text.
    }

    private void TriggerRightEnd()
    {
        // TODO Here Some text.
    }
}
