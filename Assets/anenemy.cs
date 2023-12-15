using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class anenemy : MonoBehaviour
{

    public float spheresize = 2.0f;
    public LayerMask detectionLayer;

    public NavMeshAgent navmeshagent;
    public Transform target;


    public float checkforbombsize = 0.5f;
    public LayerMask bomblayer;

    public float slashrangedetect = 2.0f;
    private Animator animator;

    void Start()
    {
        navmeshagent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bool isColliding = Physics.CheckSphere(transform.position, spheresize, detectionLayer);
        bool isBombed = Physics.CheckSphere(transform.position, checkforbombsize, bomblayer);
        bool isinslashrange = Physics.CheckSphere(transform.position, slashrangedetect, detectionLayer);
        bool isontopofme = Physics.Raycast(transform.position, Vector3.up, 2f);

        transform.LookAt(target.position);




        if(isColliding)
        {
            //Debug.Log("close to player");
            
            navmeshagent.destination = target.position;
        }

        if (isBombed)
        {
            Debug.Log("bombed");
            Destroy(gameObject);

        }

        if (isinslashrange)
        {
            //Debug.Log("in slash range");
            if (!isontopofme)
            {
                //Debug.Log("is not on top of me");
                    animator.SetTrigger("attack");

            }
        }


    }



}
