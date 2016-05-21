﻿using UnityEngine;
using System.Collections;

public class RightButton : MonoBehaviour {

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
		thingToRotate.rotation = new Quaternion (0, 180, 0, 0);
		animatio.GetComponent<Animation>().Play ("walk");
	}

	void Up()
	{
		pressed = false;
		animatio.GetComponent<Animation>().Play ("idle");

	}

	// Update is called once per frame
	public void Update () {
		if (Input.GetKey (KeyCode.RightArrow))
			Down ();
		if ((player != null && pressed) )
		{
			rigidbody.AddForce (new Vector3 (0.01f, 0, 0));
			//player.position = new Vector3 (player.position.x+0.01f, player.position.y, player.position.z);
			animatio.GetComponent<Animation> ().Play ("walk");
		}
		if (Input.touchCount == 0 && !Input.GetMouseButton (0))
		{
			Up ();
		}
	}
}
