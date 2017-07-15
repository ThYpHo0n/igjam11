using UnityEngine;
using UnityEditor;

public abstract class UberControlledObj : MonoBehaviour {
    Rigidbody2D myRB;
    Animator myAnim;

    //für laufen
    public float maxSpeed;
    bool faceRight = true;

    // für Springen
    public float jumpHigh;
    bool grounded;
    float groundCheckRadius = 1f;
    public LayerMask groundLayer;
    public Transform groundChecker;
    Collider2D[] groundCollisions;

    // Use this for initialization
    void Start() {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public abstract void Update();

    private void FixedUpdate() {
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

        print(grounded);

        float move = Input.GetAxis("Horizontal");
        myRB.velocity = new Vector2(maxSpeed * move, myRB.velocity.y);

        if ((move > 0 && !faceRight) || move < 0 && faceRight) {
            flip();
        }
    }

    void flip() {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}