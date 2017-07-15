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
    float groundCheckRadius = 0.5f;
    public LayerMask groundLayer;
    public Transform groundChecker;
    Collider2D[] groundCollisions;

    // Use this for initialization
    void Start() {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public abstract void Update();
    public abstract void Die();
    public abstract void Spawn();

    //public abstract void 

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
    }

    public void Move(float movement) {
        myRB.velocity = new Vector2(maxSpeed * movement, myRB.velocity.y);

        if ((movement > 0 && !faceRight) || movement < 0 && faceRight) {
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