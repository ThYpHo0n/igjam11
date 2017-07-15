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
            Decisions dec = new Decisions();
            dec.RightDecision += 1;
            dec.WrongDecision += 0;
            decisionList.Add(dec);

            EventManager.F_Fight(Utility.CurrentEnemy);
        }
        else
        {
            Decisions dec = new Decisions();
            dec.RightDecision += 0;
            dec.WrongDecision += 1;
            decisionList.Add(dec);
        }
    }

    public void DecisionSummary()
    {

        for (int i = 0; i < decisionList.Count; i++)
        {
            if (decisionList[i].WrongDecision > 0)
            {
                // TODO Trigger Wrong End
            }
        }
        // TODO Trigger Nice End
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
