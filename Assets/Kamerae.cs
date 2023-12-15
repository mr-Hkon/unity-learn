using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamerae : MonoBehaviour
{
    public Transform target;
    public float lockZ = -12.0f;
    public float lockY = 12;
    public Transform folg;
    Vector3 nyposition;


    void Start()
    {
        nyposition = transform.position;
    }

    private void Update()
    {
        transform.LookAt(target);
    }



    void LateUpdate()
    {

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, transform.rotation.eulerAngles.z);

        //Vector3 nyposition = transform.position;

        nyposition = new Vector3 (folg.position.x, lockY, lockZ);
        //nyposition.z =lockZ;
        //nyposition.x = folg.position.x;


        transform.position = nyposition;

    }
}
