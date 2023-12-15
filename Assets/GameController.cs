using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject ball;
    public Transform SpawnPoint;
    public float autospwnspeed;
    public float MaxX;
    public float Maxz;

      
    void Start()
    {
        SpawnBall();

        InvokeRepeating("SpawnBall", 1f, autospwnspeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBall();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;

            mousePos.z = 10f;

            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(mousePos);

            Instantiate(ball, spawnPos, Quaternion.identity);
        }
    }



    void SpawnBall()
    {
        float randomX = Random.Range(-MaxX, MaxX);
        float randomZ = Random.Range(-Maxz, Maxz);

        Vector3 randomSpawnPos = new Vector3(randomX, 5f, randomZ);

        Instantiate(ball, randomSpawnPos, Quaternion.identity);


        //Instantiate(ball, SpawnPoint.position, Quaternion.identity);
    }
}
