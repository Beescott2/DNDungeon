using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

	public GameObject m_joueur;

	// Use this for initialization
	void Start () {
		Instantiate (m_joueur, new Vector3(0, 3, 0), new Quaternion());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
