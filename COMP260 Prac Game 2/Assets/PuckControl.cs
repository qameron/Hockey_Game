using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PuckControl : MonoBehaviour
{
    public AudioClip wallCollideClip;
    private AudioSource audio;
    public Transform startingPos;
    private Rigidbody rigidbody;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        ResetPosition();
    }
    public void ResetPosition()
    {
        rigidbody.velocity = Vector3.zero;
        // teleport to the starting position
        rigidbody.MovePosition(startingPos.position);
    }

    public AudioClip paddleCollideClip;
    public LayerMask paddleLayer;
    void OnCollisionEnter(Collision collision)
    {
        // check what we have hit
        if (paddleLayer.Contains(collision.gameObject))
        {
            // hit the paddle
            audio.PlayOneShot(paddleCollideClip);
        }
        else
        {
            // hit something else
            audio.PlayOneShot(wallCollideClip);
        }
    }


    // Update is called once per frame
    void Update () {
		
	}

}
