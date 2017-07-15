using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            collision.gameObject.layer = 8;
    }
}
