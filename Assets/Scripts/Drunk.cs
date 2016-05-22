using UnityEngine;
using System.Collections;

public class Drunk : MonoBehaviour {

	public Rigidbody rid;

	public int lvlOfDrunkness = 20;

	void Update () {
		int i = Random.Range(0,1000);
		float x = Random.Range (-100 , 100 );
		float z = Random.Range (-100 , 100 );
		if(i<(lvlOfDrunkness))
			rid.AddForce(new Vector3(x*50,0,z*50));
	}
}
