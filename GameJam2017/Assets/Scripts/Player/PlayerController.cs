using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    Rigidbody2D myRB;
    Animator myAnim;

    [SerializeField] GameObject CanvasQTE;
    [SerializeField] Text textQTE;
    [SerializeField] Slider sliderQTE;

    [SerializeField] GameObject CanvasSmash;
    [SerializeField] Text textSmash;
    [SerializeField] Slider sliderSmash;

    string[] charsQTE = new string[] { "q", "w", "e", "a", "s", "d" };


    //für laufen
    public float maxSpeed;
    bool faceRight = true;

    // für Springen
    public float jumpHigh;
    bool grounded;
    float groundCheckRadius = 0.5f;
    public LayerMask groundLayer;
    public Transform groundChecker;
    Collider2D[] groundCollisions;

    // Use this for initialization
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        EventManager.Fight += StartFightAgainstEnemy;
    }

    private void StartFightAgainstEnemy(Enemy controller)
    {
        if (Utility.canWalk)
        {
            Utility.canWalk = false;
            eventQTE(5, 2, controller);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Utility.canWalk)
        {

            //for run
            float movement = Input.GetAxis("Horizontal");

            if ((movement > 0 && !faceRight) || movement < 0 && faceRight)
            {
                flip();
            }

            //for jump
            groundCollisions = Physics2D.OverlapCircleAll(groundChecker.position, groundCheckRadius, groundLayer);

            if (groundCollisions.Length > 0)
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }

            if (grounded && Input.GetAxis("Jump") > 0)
            {
                grounded = false;
                myRB.velocity = new Vector2(myRB.velocity.x, jumpHigh);
            }

            myRB.velocity = new Vector2(maxSpeed * movement, myRB.velocity.y);
        }

        //for Eventtests
        if (Input.GetKeyDown(KeyCode.Z))
        {
            eventSmash(2.5f);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            //eventQTE(5,2);
        }
    }

    void flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Tipp benutze: eventSmash(2.5) 
    public void eventSmash(float timeToZeroRelative)
    {
        StartCoroutine(ieSmash(1 / (timeToZeroRelative * 50)));
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
    public void eventQTE(int LettersToPress, float timeToClickInRelative, Enemy controller)
    {
        StartCoroutine(ieQTE(LettersToPress, 1 / (timeToClickInRelative * 50),controller));
    }

    private IEnumerator ieQTE(int LettersToPress, float timeToClick, Enemy Controller)
    {
        Utility.canWalk = false;

        CanvasQTE.SetActive(true);

        while (LettersToPress > 0)
        {

            float fightValue = 1;
            bool keyPressed = false;
            int randomLetter = UnityEngine.Random.Range(0, 6);
            textQTE.text = charsQTE[randomLetter];

            while (fightValue > 0 && !keyPressed)
            {
                if (Input.GetKeyDown(charsQTE[randomLetter]))
                {
                    keyPressed = true;
                    Controller.GetDamage(20);
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

        Utility.canWalk = true;
    }
}

