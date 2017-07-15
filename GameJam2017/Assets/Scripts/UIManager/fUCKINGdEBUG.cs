using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fUCKINGdEBUG : MonoBehaviour {
    [SerializeField]
    private GameObject player;

	
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = new Vector3(player.transform.position.x+4 , player.transform.position.y+1f, this.transform.position.z);	
	}
}
