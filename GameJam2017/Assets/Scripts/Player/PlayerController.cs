using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : UberControlledObj {

    [SerializeField] GameObject PanelQTE;
    [SerializeField] Text textQTE;
    [SerializeField] Slider sliderQTE; 

    [SerializeField] GameObject PanelSmash;
    [SerializeField] Text textSmash;
    [SerializeField] Slider sliderSmasch;

    string [] charsQTE = new string[] {"q", "w", "e", "a", "s", "d" };
    private void Start()
    {
        PanelQTE.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public override void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            QTE(5,5);
        }
	}


    public void QTE(int LettersToPress, float timeTiClickInSec)
    {

        StartCoroutine(ieQTE(LettersToPress));
    }

    public IEnumerator ieQTE(int LettersToPress)
    {
        PanelQTE.SetActive(true);

        while (LettersToPress > 0) {

            float fightValue = 1;
            bool keyPressed = false;
            int randomLetter = Random.Range(0, 6);
            textQTE.text = charsQTE[randomLetter];

            while (fightValue > 0 && !keyPressed)
            {
                if (Input.GetKeyDown(charsQTE[randomLetter]))
                {
                    keyPressed = true;
                }
                
                sliderQTE.value = fightValue -= 0.005f;
                yield return null;
            }

            if (keyPressed)
            {
                LettersToPress--;
            }
            else
            {
                break;
                //TODO: Hier Spiel verloren Event triggern
            }
        }


        PanelQTE.SetActive(false);
        yield return null;
    }
}
