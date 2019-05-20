using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
    void Update () {
        Thrust();
        Rotate();
	}

    private void Thrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rigidBody.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            if (audioSource.isPlaying) {
                audioSource.Stop();
            }
        }
    }

    private void Rotate() {

        rigidBody.freezeRotation = true; // <= TAKE MANUAL CONTROL OF ROTATION

        if (Input.GetKey(KeyCode.A)) {
            print("Rotating Left");
            transform.Rotate(Vector3.forward);
        } else if (Input.GetKey(KeyCode.D)) {
            print("Rotating Right");
            transform.Rotate(-Vector3.forward);
        } if (Input.GetKey(KeyCode.Escape)) {
            UnityEditor.EditorApplication.isPlaying = false;  // <= COMMENT OUT BEFORE RUNNING BUILD
            Application.Quit();
        }

        rigidBody.freezeRotation = false; // <= RESUME PHYSICS CONTROL OF ROTATION
    }
}
