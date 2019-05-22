using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;

    [SerializeField] float rcsThrust = 200f;
    [SerializeField] float mainThrust = 1200f;

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

        float thrustThisFrame = mainThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space)) {
            rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);
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

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A)) {
            
            print("Rotating Left");
            transform.Rotate(Vector3.forward * rotationThisFrame);

        } else if (Input.GetKey(KeyCode.D)) {
            
            print("Rotating Right");
            transform.Rotate(-Vector3.forward * rotationThisFrame);

        } if (Input.GetKey(KeyCode.Escape)) {
            UnityEditor.EditorApplication.isPlaying = false;  // <= COMMENT OUT BEFORE RUNNING BUILD
            Application.Quit();
        }

        rigidBody.freezeRotation = false; // <= RESUME PHYSICS CONTROL OF ROTATION
    }
}
