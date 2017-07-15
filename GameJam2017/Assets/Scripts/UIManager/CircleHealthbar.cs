using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleHealthbar : MonoBehaviour {
    private float health;
    [SerializeField]
    private Slider CircleHealthBar;
    // Use this for initialization
    void Start ()
    {
        health = 100;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        CircleHealthBar.value = (health/ 100);
        
	}
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            health -= 10*Time.deltaTime;
    }
} 
