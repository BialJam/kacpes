using UnityEngine;
using System.Collections;

public class śmierć : MonoBehaviour {

	public GameObject animatio;
	public Rigidbody rigid;
	bool death = false;

	public UpButton d1;
	public DownButton d2;
	public LeftButton d3;
	public RightButton d4;


	public GameObject[] notdeadColiders = new GameObject[16];
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(death)
			animatio.GetComponent<Animation>().Play ("death");
	
	}

	void OnCollisionEnter(Collision collision)
	{
		rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
		death = true;
		//d1.forceStop = true;
		//d2.forceStop = true;
		//d3.forceStop = true;
		//d4.forceStop = true;
	}
}
