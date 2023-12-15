using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playsound : MonoBehaviour
{
    public AudioSource lyd;
    public AudioClip klipplyd;
    void Start()
    {
        lyd.PlayOneShot(klipplyd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
