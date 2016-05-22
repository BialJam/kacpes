using UnityEngine;
using System.Collections;

public class RotateBottle : MonoBehaviour {

	float t = 0.0f;
	public GameObject[] stages;
	bool play = true;

	public Transform[] Glasses = new Transform[5];
	public Transform bottle;
	public TextMesh[] ScoteTextMeches = new TextMesh[5];
	private int[] mililiters = new int[5];
	public EllipsoidParticleEmitter EPE;

	private double maxHeight = 1.101;
	private double maxFat = 0.6;

	private int maxRotation = 110;
	private float maxButtleHeight = (float)1.7;

	private int glassNumber =0;

	// Use this for initialization
	void Start () {
		foreach (Transform g in Glasses)
		{
			g.localPosition = new Vector3(g.localPosition.x,(float)0.5, g.localPosition.z);
			g.localScale = new Vector3 ((float)0.75, (float)0,(float) 0.75);
		}

		foreach (TextMesh Tm in ScoteTextMeches) {
			Tm.text = "--%";
		}

		EPE.emit = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) || Input.GetMouseButton (0)) {
			if (bottleTurn (true)) {
                if (glassNumber < Glasses.Length)
                {
                    Transform g = Glasses[glassNumber];
                    if (g.localScale.y < maxFat && bottle.localScale.y > 0.1)
                    {
                        EPE.emit = true;

                        g.position = new Vector3(g.position.x, g.position.y + (float)0.001, g.position.z);
                        g.localScale += new Vector3(0, (float)0.011, 0);
                        bottle.localPosition = new Vector3(bottle.localPosition.x, bottle.localPosition.y - (float)0.011, bottle.localPosition.z);
                        bottle.localScale -= new Vector3(0, (float)0.012, 0);
                    }
                    else
                        EPE.emit = false;

                }


                

            }	
			if (glassNumber >= Glasses.Length)
				Application.LoadLevel("tavern");
		} else {
			if (bottleTurn (false)) {
				if (Input.GetMouseButtonUp (0)) 
				{
					if (glassNumber < Glasses.Length)
					{
							EPE.emit = false;
							mililiters [glassNumber] = (int)(Glasses [glassNumber].localScale.y * 1000);
							ScoteTextMeches [glassNumber].text = (((100 * mililiters [glassNumber]) / mililiters [0]) - 100).ToString () + "%";
							glassNumber++;
					}
				}
			}
		}
	}

	private bool bottleTurn(bool direction)
	{
		bool returned = false;
		
		if (direction) 
		{
			if (play == true && t < 1.0f) {
				this.transform.Translate ((Vector3.zero - this.transform.position) + getBezier ());
				this.transform.eulerAngles = new Vector3 (t * 90, t * 15, t * 50);
			} else
				returned = true;

			//if (Input.acceleration.z > 0.7853981634) {
				if (t < 1.0f)
					t += 0.010f;
			//} else {
			//	if (t > 0.0f)
			//		t -= 0.010f;
			//}
		}
		else
		{
			if (play == true &&t<1.0f)
			{
				this.transform.Translate ((Vector3.zero - this.transform.position) + getBezier());
				this.transform.eulerAngles = new Vector3 (t * 90, t*15, t * 50);
			} else
				returned = true;
			if (t > 0.0f)
				t -= 0.010f;
		}

		return returned;
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
}
