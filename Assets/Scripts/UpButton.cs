using UnityEngine;
using System.Collections;

public class UpButton : MonoBehaviour {

	public Transform player;
	public Transform thingToRotate;
	public Rigidbody rigidbody;
	public float maxVelocity = 25f;

	public float force = 30f;

	// Use this for initialization
	void Start () {
	
	}

	public bool forceStop=false;

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
	public void FixedUpdate () {
		if (forceStop)
			return;
		if ((player != null && pressed) || Input.GetKey (KeyCode.UpArrow)) {
			if(!(rigidbody.velocity.x>maxVelocity))
			rigidbody.AddForce (new Vector3 (0, 0, force));
			Vector3 eA = thingToRotate.eulerAngles;
			eA.y = 0;
			thingToRotate.eulerAngles = eA;
			//player.position = new Vector3 (player.position.x, player.position.y, player.position.z + 0.01f);
			animatio.GetComponent<Animation> ().Play ("walk");
		}
		if (Input.touchCount == 0 && !Input.GetMouseButton (0) && !Input.GetKey(KeyCode.DownArrow)&& !Input.GetKey(KeyCode.UpArrow)&& !Input.GetKey(KeyCode.LeftArrow)&& !Input.GetKey(KeyCode.RightArrow))
		{
			Up ();
			animatio.GetComponent<Animation>().Play ("idle");
		}
	}
}
