using UnityEngine;
using System.Collections;

public class bzier : MonoBehaviour {

	float t = 0.0f;
	//GameObject bottle;

	public GameObject[] stages;


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

	bool play = true;

	// Use this for initialization
	void Start () {
		//bottle = GameObject.FindGameObjectWithTag ("Bottle");
		//stages = new GameObject[4];
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
	void Update () 
	{
		
	}
}
