using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField]
    private FirstLevelPictureStory loadManager;
	// Use this for initialization
	void Start ()
    {
        loadManager = GetComponent<FirstLevelPictureStory>();
        loadManager.StartGameStory();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
