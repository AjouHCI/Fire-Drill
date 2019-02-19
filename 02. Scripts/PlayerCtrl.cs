using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
	private float h = 0.0f;
	private float v = 0.0f;

	private Transform tr;
	public float movespeed = 10.0f;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		//Debug.Log("h = " + h.ToString());
		//Debug.Log("v = " + v.ToString());

		Vector3 moveDir = Vector3.forward * v + Vector3.right * h;
		tr.Translate(moveDir.normalized * movespeed * Time.deltaTime, Space.Self);
	}
}
