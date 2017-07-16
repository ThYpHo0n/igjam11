using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowIceblock : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {   if(Utility.icewallMove)
        this.transform.position = new Vector3(this.transform.position.x + 2*Time.deltaTime, this.transform.position.y, this.transform.position.z);
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            GameController.Instance.TriggerWrongEnd();
        }
    }
}
