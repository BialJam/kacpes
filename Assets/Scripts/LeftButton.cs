﻿using UnityEngine;
using System.Collections;

public class LeftButton : MonoBehaviour {

	public Transform player;
	public Transform thingToRotate;
	public Rigidbody rigidbody;
	public float force = 30f;
	public float maxVelocity = 25f;
	// Use this for initialization
	void Start () {

	}

	public bool pressed = false;
	public GameObject animatio;

	void Down()
	{
		pressed = true;
		animatio.GetComponent<Animation>().Play ("walk");
	}

	void Up()
	{
		pressed = false;
		animatio.GetComponent<Animation>().Play ("idle");

	}

	// Update is called once per frame
	public void Update () {
		if (pressed ||Input.GetKey(KeyCode.LeftArrow))
		{
			if(!(rigidbody.velocity.x>maxVelocity))
			if(pressed)
				rigidbody.AddForce (new Vector3 (-force, 0, 0));
			else
				rigidbody.AddForce (new Vector3 (-force, 0, 0));
			thingToRotate.rotation = new Quaternion (0, 0, 0, 0);
			//player.position = new Vector3 (player.position.x-0.01f, player.position.y, player.position.z);
			animatio.GetComponent<Animation> ().Play ("walk");
		}
		if (Input.touchCount == 0 && !Input.GetMouseButton (0) && !Input.GetKey(KeyCode.DownArrow)&& !Input.GetKey(KeyCode.UpArrow)&& !Input.GetKey(KeyCode.LeftArrow)&& !Input.GetKey(KeyCode.RightArrow))
		{
			Up ();
		}
	}
}