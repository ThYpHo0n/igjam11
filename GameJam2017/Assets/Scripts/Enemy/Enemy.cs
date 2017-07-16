using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject CanvasObject;

    private GameObject player;

    public int Life = 100;

    public float distance;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Penischen!");    // dis is a penischen
        player = GameObject.FindWithTag("Player");
        CanvasObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        distance = Vector3.Distance(this.transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance <= 2.5f)
        {
            Utility.canWalk = false;
            CanvasObject.SetActive(true);
            Utility.CurrentEnemy = this;
        }
    }

    public void ResetLife()
    {
        this.Life = 100;
    }

    public void GetDamage(int damage)
    {
        if (Life <= 20)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Life -= damage;
        }
    }
}
