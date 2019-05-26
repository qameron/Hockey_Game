using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePaddle : MonoBehaviour {

    public float speed = 20f;
    public float force = 10f;
    public float forceAmount = 2f;

    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movedir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        print(movedir);
        rigidbody.AddForce(movedir * forceAmount);
    }

    void FixedUpdate()
    {
        
        // TEST
       
        /**
        // the vertical axis controls acceleration fwd/back
        float forwards = Input.GetAxis("Vertical");
        if (forwards > 0)
        {
            // accelerate forwards
            rigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * 8);
        }
        else if (forwards < 0)
        {
            // accelerate backwards
            rigidbody.MovePosition(transform.position - transform.forward * Time.deltaTime * 8);
        }

        float sidewards = Input.GetAxis("Horizontal");
        if (sidewards > 0)
        {
            // accelerate forwards
            rigidbody.MovePosition(transform.position + transform.right * Time.deltaTime * 8);
        }
        else if (sidewards < 0)
        {
            // accelerate backwards
            rigidbody.MovePosition(transform.position - transform.right * Time.deltaTime * 8);
        }

        // TEST




        **/
        /**  Vector3 pos = GetMousePosition();
          Vector3 dir = pos - rigidbody.position;
          Vector3 vel = dir.normalized * speed;
          // check is this speed is going to overshoot the target
          float move = speed * Time.fixedDeltaTime;
          float distToTarget = dir.magnitude;
          if (move > distToTarget)
          {
              // scale the velocity down appropriately
              vel = vel * distToTarget / move;
          }
          rigidbody.velocity = vel;
      **/
    }





    private Vector3 GetMousePosition()
    {
        // create a ray from the camera
        // passing through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // find out where the ray intersects the XZ plane
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance = 0;
        plane.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    void OnDrawGizmos()
    {
        // draw the mouse ray
        Gizmos.color = Color.yellow;
        Vector3 pos = GetMousePosition();
        Gizmos.DrawLine(Camera.main.transform.position, pos);
    }

}
