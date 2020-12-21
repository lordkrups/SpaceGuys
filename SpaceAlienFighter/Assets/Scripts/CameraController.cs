using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public Vector3 cameraOffset;


    public Transform pivot;

    [Range(0.01f, 1f)]
    public float SmoothFactor = 0.5f;

    private bool track = true;

    // Start is called before the first frame update
    void Start()
    {
        pivot.transform.position = target.transform.position;
        pivot.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        pivot.transform.parent = target.transform;
        cameraOffset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (track)
        {
            Vector3 newPos = target.position + cameraOffset;

            transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
            //transform.LookAt(target);    
        }

    }

    public void RotateCamera(int dir)
    {
        //track = false;
        Vector3 finalOffset = new Vector3(0,1f,0);

        switch (dir)
        {

            case 1:
                //transform.Rotate(new Vector3(0, 1f, 0), 10f);
                //transform.rotation = Quaternion.AngleAxis(10f, target.position);
                /*Quaternion.AngleAxis(10f, Vector3.up) * finalOffset;*/

                transform.RotateAround(target.position, new Vector3(0, 1, 0), 10f);
                target.RotateAround(target.position, new Vector3(0, 1, 0), 10f);
                cameraOffset = transform.position - target.position;


                //transform.LookAt(target);    
                break;

            case 2:
                //transform.Rotate(new Vector3(0, 1f, 0), -10f);
                break;

            default:
                break;
        }
        //track = true;

    }
}
