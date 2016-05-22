using UnityEngine;
using System.Collections;

public class RightButton : MonoBehaviour {

	public Transform player;
	public Transform thingToRotate;
	public Rigidbody rigidbody;
	public float maxVelocity = 25f;

	public float force = 30f;
	public bool forceStop=false;

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
	public void FixedUpdate () {
		if (forceStop)
			return;
		if (Input.GetKey (KeyCode.RightArrow))
			Down ();
		if ((player != null && pressed) )
		{
			if(!(rigidbody.velocity.x>maxVelocity))
			rigidbody.AddForce (new Vector3 (force, 0, 0));
			Vector3 eA = thingToRotate.eulerAngles;
			eA.y = 90;
			thingToRotate.eulerAngles = eA;
			//player.position = new Vector3 (player.position.x+0.01f, player.position.y, player.position.z);
			animatio.GetComponent<Animation> ().Play ("walk");
		}
		if (Input.touchCount == 0 && !Input.GetMouseButton (0) && !Input.GetKey(KeyCode.DownArrow)&& !Input.GetKey(KeyCode.UpArrow)&& !Input.GetKey(KeyCode.LeftArrow)&& !Input.GetKey(KeyCode.RightArrow))
		{
			Up ();
			//rigidbody. = new Vector3 (0, 0, 0);
		}
	}
}
