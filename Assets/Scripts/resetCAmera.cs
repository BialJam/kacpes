using UnityEngine;
using System.Collections;

public class resetCAmera : MonoBehaviour {

	public Transform placeTo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(placeTo!=null)
		{
			this.transform.position = new Vector3 (placeTo.position.x,this.transform.position.y, placeTo.position.z);
		}
			
		if (Input.GetKeyDown (KeyCode.Q) || Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Backspace))
			Application.LoadLevel ("Menu");
	}
}
