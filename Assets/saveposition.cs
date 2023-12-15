using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveposition : MonoBehaviour
{

    private Transform playerlocation;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerlocation = transform;
        loadplayerposition();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            saveplayerposition(); 
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            loadplayerposition();
        }

    }


    private void saveplayerposition()
    {
        PlayerPrefs.SetFloat("PlayerX", playerlocation.position.x);
        PlayerPrefs.SetFloat("PlayerY", playerlocation.position.y);
        PlayerPrefs.SetFloat("PlayerZ", playerlocation.position.z);
        PlayerPrefs.Save();
    }


    private void loadplayerposition()
    {
        float Px = PlayerPrefs.GetFloat("PlayerX");
        float Py = PlayerPrefs.GetFloat("PlayerY");
        float Pz = PlayerPrefs.GetFloat("PlayerZ");

        rb.velocity = new Vector3(0f, 0f, 0f);

        playerlocation.position = new Vector3(Px, Py, Pz);
    }


}
