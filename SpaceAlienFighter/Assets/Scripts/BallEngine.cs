using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEngine : MonoBehaviour
{
    Rigidbody rb;

    float xInput, zInput;

    public float speed;

    public Material greenMat;
    public Material redTexture;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material = greenMat;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 500);
        }

        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput * speed, 0, zInput * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Destroys this object 
            //Destroy(gameObject);

            //Destroys object object collided with
            Destroy(collision.gameObject);
        }

        //GetComponent<Renderer>().material.color = Color.red;
        GetComponent<Renderer>().material = redTexture;
    }

    private void OnCollisionExit(Collision collision)
    {
        //GetComponent<Renderer>().material.color = Color.green;
        GetComponent<Renderer>().material = greenMat;

    }
}
