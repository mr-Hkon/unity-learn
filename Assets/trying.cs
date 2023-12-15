using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class trying : MonoBehaviour
{
    Rigidbody rb;
    public float jumpforce;
    public float walljump;
    public float cooldownbomb;

    public float inputX;
    public float inputZ;

    public float MoveSpeed;

    public GameObject enemyspawn;
    public GameObject kuben;

    public GameObject bomba;
    public Transform bombspawn;


    public AudioClip coinlyd;


    public bool isonground;
    public bool isclosetoground;
    public bool isonwallR;//r for right
    public bool isonwallL;
    public bool isonwallF; //f for forward   (front funke kje)
    public bool isonwallB;
    public bool closetoground;// sjekk om det e kort ner te bakken, hvis du e nærme bakken ska du kje konna walljumpa


    public AudioSource audiosourcen;
    public AudioClip veggkrasj;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        isonground = Physics.Raycast(transform.position, Vector3.down, 1.5f);
        isonwallR = Physics.Raycast(transform.position, Vector3.right, 1f);
        isonwallL = Physics.Raycast(transform.position, Vector3.left, 1f);
        isonwallF = Physics.Raycast(transform.position, Vector3.forward, 1f);
        isonwallB = Physics.Raycast(transform.position, -Vector3.forward, 1f);
        isclosetoground = Physics.Raycast(transform.position, Vector3.down, 2f);



        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isonground == true)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(Vector3.up * jumpforce);
            }
            if (isclosetoground == false)
            {
                if (isonwallR == true)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                    rb.AddForce(Vector3.up * walljump / 1);
                    rb.AddForce(Vector3.left * jumpforce);
                }
                if (isonwallL == true)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                    rb.AddForce(Vector3.up * walljump/1);
                    rb.AddForce(Vector3.right * jumpforce);
                }
                if (isonwallF == true)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                    rb.AddForce(Vector3.up * walljump/1);
                    rb.AddForce(-Vector3.forward * jumpforce);
                }
                if (isonwallB == true)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                    rb.AddForce(Vector3.up * walljump / 1);
                    rb.AddForce(Vector3.forward * jumpforce);
                }
            }
            

        }

        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        rb.AddForce (inputX * MoveSpeed, 0 , inputZ * MoveSpeed);

      /* if (Input.GetKey(KeyCode.Q))
        {
            Instantiate(bomba, bombspawn.position, bombspawn.rotation);
        }*/

       if (cooldownbomb > 0)
        {
            cooldownbomb -= Time.deltaTime;
        }

       if (cooldownbomb <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(bomba, bombspawn.position, bombspawn.rotation);
                cooldownbomb = 0.5f;
            }
        }

        //Debug.Log(cooldownbomb);



        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("h");
        }
    }






    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            GetComponent<Renderer>().material.color = Color.black;
            Instantiate (kuben, enemyspawn.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "coin")
        {

            //GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().PlayOneShot(coinlyd);


            Destroy(collision.gameObject);

        }


        if (collision.gameObject.tag == "bakke")
        {
            audiosourcen.PlayOneShot(veggkrasj);
        }
    }


}
