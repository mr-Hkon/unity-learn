using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class test : MonoBehaviour
{

    Rigidbody rb;
    public GameObject wintxt;
    float xinput;
    float zinput;

    public float speed;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 100);
        }

        //rb.velocity = Vector3.forward * 5;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("scene2");
        }

        xinput = Input.GetAxis("Horizontal");
        zinput = Input.GetAxis("Vertical");

        rb.AddForce(xinput * speed, 0, zinput*speed);


    }



    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Destroy(gameObject);
            Destroy(collision.gameObject);
            wintxt.SetActive(true);
        }
    }




}
