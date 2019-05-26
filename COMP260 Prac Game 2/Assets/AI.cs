using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

 
    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    private bool dirForward = true;
    public float speed = 2.0f;

    void Update()
    {
        if (dirForward)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        else
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z >= 2.0f)
        {
            dirForward = false;
        }

        if (transform.position.z <= -2)
        {
            dirForward = true;
        }
    }

}






 

 

