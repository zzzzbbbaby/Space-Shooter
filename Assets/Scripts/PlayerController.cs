﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	public Boundary boundary;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn; //shotSpawn.position

	private float nextfire;
	public float fireRate;

	private AudioSource audioSource;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
	
	}

	void Update(){
		if (Input.GetButton("Fire1") && Time.time > nextfire ){
			nextfire =Time.time +fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			audioSource.Play ();
		}
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;
		rb.position = new Vector3(Mathf.Clamp(rb.position.x,boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
		rb.rotation = Quaternion.Euler (0, 0, rb.position.x * -tilt);
	}
}
