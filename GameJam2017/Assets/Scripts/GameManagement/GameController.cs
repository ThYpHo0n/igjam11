using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController Instance;
    public GameObject CanvasBadEnd;
    public GameObject CanvasGoodEnd;
    private int MonsterFight = 0;
    
    [SerializeField]
    private FirstLevelPictureStory loadManager;


    public GameObject GameOverScreen;
    List<Decisions> decisionList = new List<Decisions>();

	// Use this for initialization
	void Start ()
    {
        if (Instance == null)
            Instance = this;
        GameOverScreen.SetActive(false);
        EventManager.gameOver += GameOver;
        loadManager = GetComponent<FirstLevelPictureStory>();
        loadManager.StartGameStory();
	}

    private void GameOver()
    {
        StartCoroutine("StartGameOver");
    }

    IEnumerator StartGameOver()
    {
        yield return new WaitForSeconds(.75f);
        GameOverScreen.SetActive(true);
        AudioManager.instance.PlayGameOverSound("Death", "GameOver");
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("MainMenu");
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
            Utility.canWalk = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().reduceMentalLive(25);
            Destroy(Utility.CurrentEnemy.gameObject);
        }
    }

    public void DecisionSummary()
    {

        for (int i = 0; i < decisionList.Count; i++)
        {
            if (decisionList[i].WrongDecision > 0)
            {
                TriggerWrongEnd();
                return;
            }
          
        }

        TriggerRightEnd();
    }


    public void TriggerWrongEnd()
    {
        CanvasBadEnd.SetActive(true);
    }

    private void TriggerRightEnd()
    {
        CanvasGoodEnd.SetActive(true);
    }
}
