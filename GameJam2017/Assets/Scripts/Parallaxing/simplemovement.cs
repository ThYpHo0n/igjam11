using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplemovement : MonoBehaviour
{
    // just for debugging
    [SerializeField]

    private int Speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.position += Vector3.up *10* Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed = Speed + 5;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = Speed - 5;
        }
    }
}
