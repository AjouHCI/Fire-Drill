using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR;

public class MoveCtrl : MonoBehaviour {

	public enum MoveType{
		WAY_POINT,
		LOOK_AT,
		DAYDREAM
	}

	public MoveType movetype = MoveType.LOOK_AT;//WAY_POINT;
	public float moveSpeed = 1.0f;
	public float rotSpeed = 40.0f;
	private float damping = 3.0f;

	private Transform tr;
	private Transform camTr;
	private CharacterController cc;

	private Transform[] points;
	private int nextIdx = 1;

    private Vector3 prepos;
    private Vector3 curpos;

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
        camTr = Camera.main.GetComponent<Transform>();
        prepos = camTr.position;
        //Debug.Log("pre: " + prepos);
        cc = GetComponent<CharacterController>();
        
        points = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("Speed: " + moveSpeed);
		switch(movetype){
			case MoveType.WAY_POINT:
				MoveWayPoint();
				break;
			case MoveType.LOOK_AT:
				MoveLookAt();
				break;
			case MoveType.DAYDREAM:
				break;
		}

        curpos = camTr.position;
        //Debug.Log("cur: " + curpos);
    }

    private void LateUpdate()
    {
        prepos = curpos;

    }

    void MoveWayPoint(){
		Vector3 direction = points[nextIdx].position - tr.position;
		Quaternion rot = Quaternion.LookRotation(direction);

		tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);

		// if (controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip)){
		// 	Debug.Log(controller.index + " Grip button unpressed");

		// 	if (moveSpeed != 0)
		// 		moveSpeed = 1.0f;
		// 	else
		// 		moveSpeed = 0.0f;
		// }

		tr.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
	}

	void OnTriggerEnter(Collider coll){
		if(coll.CompareTag("WAY_POINT")){
			//Debug.Log("!@#$%");
			nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;
		}
	}

	void MoveLookAt(){
	 	Vector3 dir = camTr.TransformDirection(Vector3.forward);
	 	//tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);
	 	cc.SimpleMove(dir * moveSpeed);
	}

}
