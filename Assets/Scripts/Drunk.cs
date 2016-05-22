using UnityEngine;
using System.Collections;

public class Drunk : MonoBehaviour {

	public Rigidbody rid;

	public int lvlOfDrunkness = 20;

	void Update () {
		int i = Random.Range(0,1000);
		if(i<(lvlOfDrunkness))
			rid.AddForce(new Vector3(Random.Range(-500*lvlOfDrunkness,500*lvlOfDrunkness),0,Random.Range(-500*lvlOfDrunkness,500*lvlOfDrunkness)));
	}
}
