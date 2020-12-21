using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEngine : MonoBehaviour
{
    Rigidbody rb;
    public float dragRate;
    public float minDrag;
    public float maxDrag;
    float xInput, zInput;

    public float moveSpeed;

    public Material greenMat;
    public Material redTexture;

    public AudioClip coinAudio;

    public FloatingJoystick floatingJoystick;

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

        //xInput = Input.GetAxis("Horizontal");
        //zInput = Input.GetAxis("Vertical");

        //rb.AddForce(xInput * moveSpeed, 0, zInput * moveSpeed);
    }

    private void FixedUpdate()
    {
/*        float xVelocity = xInput * moveSpeed;
        float zVelocity = zInput * moveSpeed;*/

        //rb.velocity = new Vector3(xVelocity, rb.velocity.y, zVelocity);

        Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        rb.AddForce(direction * moveSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        if (floatingJoystick.isPressed == false && rb.drag <= maxDrag)
        {
            rb.drag += dragRate;
        } 
        else if (floatingJoystick.isPressed == true && rb.drag >= minDrag)
        {
            rb.drag -= dragRate / 2;
        }

        Debug.Log("Velocity: "+rb.velocity);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            GetComponent<AudioSource>().PlayOneShot(coinAudio);
            //Destroys object object collided with
        }
    }
}
