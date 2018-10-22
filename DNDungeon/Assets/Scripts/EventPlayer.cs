using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlayer : MonoBehaviour {

	public float m_speed;
	public Camera m_camera;

	private bool m_freeMode = false;
	private Vector2 m_lastRightClick;

	// Use this for initialization
	void Start () {

	}

	void activateFreeMode()
	{
		if (!m_freeMode)
			putFreeMode(true);
	}

	void deactivateFreeMode()
	{
		if (m_freeMode)
			putFreeMode(false);
	}


	void putFreeMode(bool freeMode)
	{
		m_freeMode = freeMode;

		if (freeMode)
			m_speed *= 10;
		else
			m_speed /= 10;

		GetComponent<Rigidbody>().isKinematic = freeMode;
		Collider[] l_colliders = GetComponentsInChildren<Collider>();
		for (int i = 0; i < l_colliders.Length; i++)
		{
			l_colliders[i].enabled = !freeMode;
		}
	}

	// Update is called once per frame
	void Update () {
		Vector3 translation = new Vector3();

		if (m_freeMode)
		{
			translation += Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f)).direction.normalized * Input.GetAxis("Vertical");
			Camera.main.transform.Rotate(Vector3.up * 90.0f);
			translation += Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f)).direction.normalized * Input.GetAxis("Horizontal");
			Camera.main.transform.Rotate(Vector3.up * -90.0f);
		}
		else
		{
			translation += Vector3.right * Input.GetAxis("Horizontal");
			translation += Vector3.forward * Input.GetAxis("Vertical");

			if ((Input.GetAxis("Horizontal") != 0) && (Input.GetAxis("Vertical") != 0))
			{
				translation = translation.normalized;
			}
		}

		translation *= m_speed * Time.deltaTime;

		if (m_freeMode)
		{
			transform.Translate(translation, Space.World);
		}
		else
		{
			transform.Translate(translation);
		}

		// CLIC DROIT : BOUGER LA CAMERA

		if (Input.GetMouseButtonDown(1))
		{
			m_lastRightClick.x = Input.mousePosition.x;
			m_lastRightClick.y = Input.mousePosition.y;
		}

		if (Input.GetMouseButton(1))
		{
			Camera.main.transform.Rotate(Vector3.right * (m_lastRightClick.y - Input.mousePosition.y) / 15.0f);
			Camera.main.transform.Rotate(Vector3.up * (Input.mousePosition.x - m_lastRightClick.x) / 15.0f, Space.World);

			m_lastRightClick.x = Input.mousePosition.x;
			m_lastRightClick.y = Input.mousePosition.y;
		}

		// A E SPACE M

		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate(new Vector3(0.0f, -1.5f, 0.0f));
		}

		if (Input.GetKey (KeyCode.E)) {
			transform.Rotate (new Vector3 (0.0f, 1.5f, 0.0f));
		}

		if (Input.GetKeyDown(KeyCode.Space)  &&  !m_freeMode) {
			GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
		}
		if (Input.GetKey(KeyCode.Space)  &&  m_freeMode)
		{
			transform.Translate(Vector3.up * m_speed * Time.deltaTime);
		}

		if (Input.GetKeyUp(KeyCode.M))
		{
			if (m_freeMode)
			{
				deactivateFreeMode();
			}
			else
			{
				activateFreeMode();
			}
		}
	}
}