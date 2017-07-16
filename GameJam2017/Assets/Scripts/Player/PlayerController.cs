using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    // Zeug aus dem Spielgeschehen
    Rigidbody2D myRB;
    Animator myAnim;

    [SerializeField] GameObject CanvasQTE;
    [SerializeField] Text textQTE;
    [SerializeField] Slider sliderQTE;

    [SerializeField] GameObject CanvasSmash;
    [SerializeField] Text textSmash;
    [SerializeField] Slider sliderSmash;

    // für QTE
    string[] charsQTE = new string[] { "q", "w", "e", "a", "s", "d" };

    //Spieler Eigenschaften
    float live;
    float mentalLive;

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
        myAnim = GetComponent<Animator>();
        myAnim.SetBool("dead", false);
        myRB = GetComponent<Rigidbody2D>();
        EventManager.Fight += StartFightAgainstEnemy;

        live = 100;
        mentalLive = 100;
    }

    private void StartFightAgainstEnemy(Enemy controller)
    {
        Utility.canWalk = false;
        eventQTE(5, 2, controller);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        //for jump & jumpAnimation
        groundCollisions = Physics2D.OverlapCircleAll(groundChecker.position, groundCheckRadius, groundLayer);

        if (groundCollisions.Length > 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        // for run & runAnimation
        float movement = Input.GetAxis("Horizontal");

        if (Utility.canWalk)
        {
            //for run
            if ((movement > 0 && !faceRight) || movement < 0 && faceRight)
            {
                flip();
            }
            myRB.velocity = new Vector2(maxSpeed * movement, myRB.velocity.y);

            // for Jump
            if (grounded && Input.GetAxis("Jump") > 0)
            {
                grounded = false;
                myRB.velocity = new Vector2(myRB.velocity.x, jumpHigh);
            }
        }

        myAnim.SetBool("grounded", grounded);
        myAnim.SetFloat("movement", Math.Abs(movement));
        myAnim.SetFloat("jumpDirection", GetComponent<Rigidbody2D>().velocity.y);

        //lebenKontrolle
        if (live <= 0 || mentalLive <= 0)
        {
            myAnim.SetBool("dead", true);
            //TODO Hier dead Event triggern
        }


        //for Eventtests
        if (Input.GetKeyDown(KeyCode.Z))
        {
            myAnim.SetBool("dead", true);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            myAnim.SetBool("attack", true);
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
        StartCoroutine(ieQTE(LettersToPress, 1 / (timeToClickInRelative * 50), controller));
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
                myAnim.SetBool("attack", true);
            }
            else
            {
                Controller.GetComponent<Animator>().SetBool("attack", true);
                live -= 10;
                break;
            }
        }


        CanvasQTE.SetActive(false);
        yield return null;

        Utility.canWalk = true;
    }
}

