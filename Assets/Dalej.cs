using UnityEngine;
using System.Collections;

public class Dalej : MonoBehaviour {

	public Transform cam;

	void Down()
	{
		cam.Rotate (new Vector3 (0, 180, 0));
	}

}
