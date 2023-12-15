using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject cube = GameObject.FindWithTag("kube");

        Destroy(cube);


    }

    // Update is called once per frame
    void Update()
    {
    }
}
