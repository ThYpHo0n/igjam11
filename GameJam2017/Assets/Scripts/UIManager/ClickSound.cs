using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour {
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip hover;
    [SerializeField]
    private AudioClip click;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Onhover()
    {
        source.PlayOneShot(hover);
    }

    public void Onclick()
    {
        source.PlayOneShot(click);
    }


}
