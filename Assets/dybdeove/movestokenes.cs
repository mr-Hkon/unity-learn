using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movestokenes : MonoBehaviour
{

    Rigidbody rb;

    public float movespeed;
    public float jumpspeed;

    public float xinput;
    public float zinput;

    public bool IsOnGround;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        IsOnGround = Physics.Raycast(transform.position, Vector3.down, 1f);



        if (Input.GetKey(KeyCode.Space))
        {
            if (IsOnGround==true)
            {
                rb.AddForce(Vector3.up*jumpspeed);
            }
        }

        xinput = Input.GetAxis("Horizontal");
        zinput = Input.GetAxis("Vertical");

        rb.AddForce(xinput*movespeed,0,zinput*movespeed);
    }
}
