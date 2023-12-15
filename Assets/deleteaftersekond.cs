using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteaftersekond : MonoBehaviour
{
    public float nedtelling;


    void Start()
    {
        Destroy(gameObject, nedtelling);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
