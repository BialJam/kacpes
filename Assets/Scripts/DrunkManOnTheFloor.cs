using UnityEngine;
using System.Collections;

public class DrunkManOnTheFloor : MonoBehaviour {


	float t = 0.0f;
	//GameObject bottle;
	float t2 = 0.0f;
	public GameObject[] stages;

	bool backWord = false;

	/*public GameObject setBezier1
	{
		set
		{
			this.stages [0] = value;
		}

		get 
		{
			return this.stages [0];
		}
	}*/

	public float speed =0.0025f;
	public float strenght =0.0025f;
	bool play = true;


	// Use this for initialization
	void Start () {
	
	}


	public Vector3 getBezier ()
	{
		float x = (1 - t) * (1 - t) * (1 - t) * stages [0].transform.position.x +
			3 * (1 - t) * (1 - t) * t * stages [1].transform.position.x + 3 * (1 - t) * t * t * stages [2].transform.position.x + t * t * t * stages [3].transform.position.x;
		float y = (1 - t) * (1 - t) * (1 - t) * stages [0].transform.position.y +
			3 * (1 - t) * (1 - t) * t * stages [1].transform.position.y + 3 * (1 - t) * t * t * stages [2].transform.position.y + t * t * t * stages [3].transform.position.y;
		float z = (1 - t) * (1 - t) * (1 - t) * stages [0].transform.position.z +
			3 * (1 - t) * (1 - t) * t * stages [1].transform.position.z + 3 * (1 - t) * t * t * stages [2].transform.position.z + t * t * t * stages [3].transform.position.z;

		return new Vector3(x,y,z);
	}
	// Update is called once per frame
	void Update () {

		if (t < 1.0f && backWord == false) {
			t += 0.01f;
		}/* else {
			t = 0.0f;
		}*/

		if (t > 1.0f) {
			backWord = true;
		}

		if (t <0.0f) {
			backWord= false;
		}

		if (t > 0.0f && backWord == true) {
			t -= 0.01f;
		}

		this.transform.LookAt (getBezier(), new Vector3 (0, 1, 0));

		t2 += speed;

		foreach (GameObject ob in stages) {
			ob.transform.position += new Vector3 (0, Mathf.Cos (t2*180), 0)*strenght;
		}

	}
}
