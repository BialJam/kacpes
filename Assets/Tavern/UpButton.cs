﻿using UnityEngine;
using System.Collections;

public class UpButton : MonoBehaviour {

	public Transform player;
	public Transform thingToRotate;
	public Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
	
	}

	public bool pressed = false;
	public GameObject animatio;

	void Down()
	{
		pressed = true;
		thingToRotate.rotation = new Quaternion (0, 90, 0, 0);
		animatio.GetComponent<Animation>().Play ("walk");
	}

	void Up()
	{
		pressed = false;
		animatio.GetComponent<Animation>().Play ("idle");

	}

	// Update is called once per frame
	public void Update () {
		if ((player != null && pressed) || Input.GetKey (KeyCode.UpArrow)) {
			rigidbody.AddForce (new Vector3 (0, 0, 10f));
			//player.position = new Vector3 (player.position.x, player.position.y, player.position.z + 0.01f);
			animatio.GetComponent<Animation> ().Play ("walk");
		}
		if (Input.touchCount == 0 && !Input.GetMouseButton (0))
		{
			Up ();
			animatio.GetComponent<Animation>().Play ("idle");
		}
	}
}
