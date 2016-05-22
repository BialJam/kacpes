using UnityEngine;
using System.Collections;

public class MoverRayCast : MonoBehaviour {

	public LayerMask touchInputMask;

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray,out hit,touchInputMask))
			{
				GameObject recipient = hit.transform.gameObject;
				recipient.SendMessage ("Down", hit.point, SendMessageOptions.DontRequireReceiver);
			}
		}
		if(Input.GetMouseButtonUp(0) || !Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray,out hit,touchInputMask))
			{
				GameObject recipient = hit.transform.gameObject;
				recipient.SendMessage ("Up", hit.point, SendMessageOptions.DontRequireReceiver);
			}
		}

		foreach(Touch t in Input.touches)
		{
			Ray ray = Camera.main.ScreenPointToRay (t.position);
			RaycastHit hit;

			if(Physics.Raycast(ray,out hit,touchInputMask))
			{
				GameObject recipient = hit.transform.gameObject;

				if (t.phase == TouchPhase.Began)
					recipient.SendMessage ("Down", hit.point, SendMessageOptions.DontRequireReceiver);
				if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
					recipient.SendMessage ("Up", hit.point, SendMessageOptions.DontRequireReceiver);
				
			}
				
		}

}
}
