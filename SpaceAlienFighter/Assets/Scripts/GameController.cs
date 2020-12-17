using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject ball;
    public Transform startPoint;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnBall", 1f, 1f);
        //SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
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
        float x, y, z;

        x = Random.Range(-15f, 15f);
        y = Random.Range(2f, 5f);
        z = Random.Range(-15f, 15f);

        Vector3 randoSpawn = new Vector3(x, y, z);

        Instantiate(ball, randoSpawn, Quaternion.identity);
    }
}
