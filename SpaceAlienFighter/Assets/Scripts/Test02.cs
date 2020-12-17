using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test02 : MonoBehaviour
{

    Rigidbody rb;

    float xInput, zInput;

    public Text textBox;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        textBox.text = "";

        Test01 t01 = new Test01();
        t01.Start();

        //Destroy(gameObject);
        //After 3 secs
        //Destroy(gameObject, 3f);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("TestLevel");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 500);
        }

        /*        if (Input.GetKeyDown(KeyCode.W))
                {
                    rb.AddForce(Vector3.forward * 500);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    rb.AddForce(-Vector3.forward * 500);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    rb.AddForce(Vector3.right * 500);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    rb.AddForce(-Vector3.right * 500);
                }*/

        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput * speed, 0, zInput * speed);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Destroys this object 
            //Destroy(gameObject);

            //Destroys object object collided with
            Destroy(collision.gameObject);

            textBox.text = "BOO!";
        }
    }

}
 