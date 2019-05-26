﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Goal : MonoBehaviour
{
    public AudioClip scoreClip;
    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider collider)
    {
        // play score sound
        audio.PlayOneShot(scoreClip);
        // reset the puck to its starting position
        PuckControl puck =
        collider.gameObject.GetComponent<PuckControl>();
        puck.ResetPosition();
    }




    void Update () {
		
	}
}

