using UnityEngine;
using System.Collections;

public class ButtleButton : MonoBehaviour {

	public Material[] material = new Material[3];
	public Transform positionToRead;
	public float z1 = 5.6f, z2 = 9.3f, x1 = -20f, x2 = -24f;
	public float z21 = -4.3f, z22 = -2.4f, x21 = 4.2f, x22 = 5.5f;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material = material [0];
	}

	public bool pressed = true;

	// Update is called once per frame
	void Update () {
		float x = positionToRead.position.x, z = positionToRead.position.z;
		if (pressed) {
			if (x > x2 && x < x1 && z > z1 && z < z2) {
				GetComponent<Renderer> ().material = material [1];
				GetComponent<MeshCollider> ().enabled = true;
			} else {
				GetComponent<Renderer> ().material = material [0];
				GetComponent<MeshCollider> ().enabled = false;
			}
		} else {
			GetComponent<Renderer> ().material = material [2];
			if (x > x21 && x < x22 )
			if( z > z21 && z < z22) {
				Application.LoadLevel("taverna");
			}
		}
	}

	void Down()
	{
		pressed = false;
		GetComponent<Renderer> ().material = material [2];
	}
}
