using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float rotateSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, rotateSpeed);
    }


}
