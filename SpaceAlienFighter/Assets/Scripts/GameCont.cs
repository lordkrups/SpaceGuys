using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCont : MonoBehaviour
{

    public GameObject[] cubes;

    // Start is called before the first frame update
    void Start()
    {
        cubes = GameObject.FindGameObjectsWithTag("Cube");

        //Run a function with a delay
        //Invoke("ColorCubes", 2f);

        //Two ways to activate coroutines
        //StartCoroutine("ColorAllCubes");
        StartCoroutine(ColorAllCubes(5f));

        /*for (int i = 0; i < cubes.Length; i++)
          {
              int rand = Random.Range(0, 3);
              Debug.Log(rand);
              switch (rand)
              {
                  case 0:
                      cubes[i].GetComponent<Renderer>().material.color = Color.red;
                      break;
                  case 1:
                      cubes[i].GetComponent<Renderer>().material.color = Color.green;
                      break;
                  case 2:
                      cubes[i].GetComponent<Renderer>().material.color = Color.blue;
                      break;
                  default:
                      break;
              }
          }*/



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //DestroyAllCubes();
        }
    }
    void ColorCubes()
    {
        foreach (GameObject c in cubes)
        {

            int rand = Random.Range(0, 3);
            Debug.Log(rand);
            switch (rand)
            {
                case 0:
                    c.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 1:
                    c.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 2:
                    c.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                default:
                    break;
            }
        }
    }
    void DestroyAllCubes()
    {
        foreach (GameObject c in cubes)
        {
            Destroy(c);
        }
    }

    IEnumerator ColorAllCubes(float waitTime)
    {
        //yield return new WaitForSeconds(2f);

        foreach (GameObject c in cubes)
        {

            int rand = Random.Range(0, 3);
            //Debug.Log(rand);
            switch (rand)
            {
                case 0:
                    c.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 1:
                    c.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 2:
                    c.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(waitTime);

        }
    }

}
