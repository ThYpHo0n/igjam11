using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour {

    Rigidbody2D myRB;
    Animator myAnim;

    // Player
    private GameObject player;

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
    void Start () {
        myRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {

        print("Player-Dog:");
        print(Vector3.Distance(this.transform.position, player.transform.position));
        //for run
        /*float movement = Input.GetAxis("Horizontal");

        if ((movement > 0 && !faceRight) || movement < 0 && faceRight) {
            flip();
        }

        //for jump
        groundCollisions = Physics2D.OverlapCircleAll(groundChecker.position, groundCheckRadius, groundLayer);

        if (groundCollisions.Length > 0) {
            grounded = true;
        } else {
            grounded = false;
        }

        if (grounded && Input.GetAxis("Jump") > 0) {
            grounded = false;
            myRB.velocity = new Vector2(myRB.velocity.x, jumpHigh);
        }

        myRB.velocity = new Vector2(maxSpeed * movement, myRB.velocity.y);
    */
    }

    private void flip() {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
