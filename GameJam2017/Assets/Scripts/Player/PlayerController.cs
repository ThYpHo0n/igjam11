using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : UberControlledObj {

    [SerializeField] GameObject CanvasQTE;
    [SerializeField] Text textQTE;
    [SerializeField] Slider sliderQTE; 

    [SerializeField] GameObject CanvasSmash;
    [SerializeField] Text textSmash;
    [SerializeField] Slider sliderSmash;

    string [] charsQTE = new string[] {"q", "w", "e", "a", "s", "d" };

    // Update is called once per frame
    public override void Update () {
    }

    // Tipp benutze: eventSmash(2.5) 
    public void eventSmash (float timeToZeroRelative)
    {
        StartCoroutine(ieSmash(1/ (timeToZeroRelative*50)));
    }

    private IEnumerator ieSmash(float fallTime)
    {
        CanvasSmash.SetActive(true);
        bool win = false;
        float fightValue = 0.5f;

        while (fightValue > 0 && !win)
        {
            fightValue -= fallTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                fightValue += 0.1f;
            }
            
            sliderSmash.value = fightValue;

            if (fightValue >= 1)
            {
                win = true;
            }

            yield return null;
        }

        if (win)
        {
            print("win");
            // Hier Archievment aktivieren
        }
        else
        {
            print("lose");
            //TODO: hier verlieren Event Starten
        }

        CanvasSmash.SetActive(false);
        yield return null;
    }

    // Tipp: event(5,2)
    public void eventQTE(int LettersToPress, float timeToClickInRelative)
    {
        StartCoroutine(ieQTE(LettersToPress, 1/(timeToClickInRelative*50)));
    }
    
    private IEnumerator ieQTE(int LettersToPress, float timeToClick)
    {
        CanvasQTE.SetActive(true);

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
                
                sliderQTE.value = fightValue -= timeToClick;
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


        CanvasQTE.SetActive(false);
        yield return null;
    }
}
