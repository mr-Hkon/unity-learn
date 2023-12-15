using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinn : MonoBehaviour
{
    public float rotasonsped;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.right, rotasonsped);
    }
}
