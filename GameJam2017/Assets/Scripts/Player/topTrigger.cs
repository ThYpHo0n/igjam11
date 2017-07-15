using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plattform"))
            collision.gameObject.layer = 9;
    }
}
