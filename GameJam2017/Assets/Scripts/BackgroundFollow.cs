using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour {
    [SerializeField]
    private GameObject Background;
    [SerializeField]
    private GameObject Player;
	// Update is called once per frame
	void Update ()
    {
        Background.transform.position = new Vector3(Player.transform.position.x, Background.transform.position.y, Background.transform.position.z); 
	}
}
