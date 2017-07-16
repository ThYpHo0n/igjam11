using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDornTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Utility.canWalk = false;
            AudioManager.instance.PlayDeathSound("Maintheme", "Death");
        }
    }
}
