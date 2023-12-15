using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looktest : MonoBehaviour
{
    public Transform spillar;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(spillar);
    }
}
