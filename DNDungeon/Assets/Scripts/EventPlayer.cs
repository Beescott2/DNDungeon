using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlayer : MonoBehaviour {

	public float m_speed;
	public Camera m_camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 translation = new Vector3();

		translation += Vector3.right * Input.GetAxis ("Horizontal");
		translation += Vector3.forward * Input.GetAxis ("Vertical");

		Debug.Log (translation);

		if ((Input.GetAxis ("Horizontal") != 0) && (Input.GetAxis ("Vertical") != 0)) {
			translation = translation.normalized;
		}

		translation *= m_speed * Time.deltaTime;
		transform.Translate(translation);

		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (new Vector3 (0.0f, -1.5f, 0.0f));
		}

		if (Input.GetKey (KeyCode.E)) {
			transform.Rotate (new Vector3 (0.0f, 1.5f, 0.0f));
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 5, 0);
		}
	}
}
