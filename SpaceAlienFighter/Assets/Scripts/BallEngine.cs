using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEngine : MonoBehaviour
{
    Rigidbody rb;

    float xInput, zInput;

    public float moveSpeed;

    public Material greenMat;
    public Material redTexture;

    public AudioClip coinAudio;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material = greenMat;

    }

    // Start is called before the first frame update
    void Start()
    {
/*        rb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material = greenMat;*/

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

        //rb.AddForce(xInput * moveSpeed, 0, zInput * moveSpeed);
    }

    private void FixedUpdate()
    {
        float xVelocity = xInput * moveSpeed;
        float zVelocity = zInput * moveSpeed;

        rb.velocity = new Vector3(xVelocity, rb.velocity.y, zVelocity);
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
        
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().PlayOneShot(coinAudio);
            //Destroys object object collided with
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
