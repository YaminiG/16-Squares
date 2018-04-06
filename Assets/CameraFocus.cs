using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour {

	// Use this for initialization
	public Vector3 camPosition; 
	public Transform camTransform;
	public float speed = 2.5f;

	void Start() 
	{
		camTransform  = Camera.main.transform;
		camPosition = camTransform.position;
	}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit) && hit.collider.tag == "target") 
			{
				GameObject[] gobjs;
				gobjs = GameObject.FindGameObjectsWithTag("target");

				for(int i = 0; i< gobjs.Length ;i++)
				{
					if (gobjs [i] == hit.collider.gameObject) {
						camPosition.x = gobjs[i].transform.position.x;
						camPosition.y = gobjs[i].transform.position.y;
						camPosition.z += 25; // Zoom
					} 
					else
					{
						gobjs [i].SetActive (false);
					}	
				}
			

			}

		}
		camTransform.position = Vector3.Lerp(camTransform.position, camPosition, Time.deltaTime * speed);
	}
}
