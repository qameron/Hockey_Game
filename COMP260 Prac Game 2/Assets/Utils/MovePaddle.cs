using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePaddle : MonoBehaviour {

    public float speed = 20f;
    public float force = 10f;
    public float forceAmount = 2f;
    public int tester = Scorekeeper.test;

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
            rigidbody.AddForce(movedir * forceAmount);
        }


    void FixedUpdate()
    {
        
        
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
