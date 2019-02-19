using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripController : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;

	private SteamVR_Controller.Device controller{
		get{
			return SteamVR_Controller.Input((int)trackedObj.index);
		}
	}

	private Transform gripedObj;
	private Color originColor;
	private bool isGripped = false;

	void Awake(){
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	} 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(controller == null){
			Debug.Log("Controller is not detected");
			return;
		}

		if(controller.GetHairTriggerDown() && gripedObj != null){
			gripedObj.SetParent(this.transform);
			gripedObj.GetComponent<Rigidbody>().isKinematic = true;

			isGripped = true;
		}
		if(controller.GetHairTriggerUp() && gripedObj != null){
			var rb = gripedObj.GetComponent<Rigidbody>();
			if(rb != null){
				rb.isKinematic = false;
				rb.velocity = controller.velocity;
				rb.angularVelocity = controller.angularVelocity;
			}
			gripedObj.SetParent(null);
		}
	}

	void OnTriggerEnter(Collider coll){
		if(coll.tag == "WATERBALLOON" && !isGripped){
			gripedObj = coll.transform;

			var _renderer = gripedObj.GetComponent<Renderer>();
			originColor = _renderer.material.color;
			_renderer.material.color = Color.red;
		}
	}

	void OnTriggerExit(Collider coll){
		if (coll.tag == "WATERBALLOON" && gripedObj.gameObject == coll.gameObject){
			gripedObj.GetComponent<Renderer>().material.color = originColor;
			gripedObj = null;

			isGripped = false;
		}
	}
}
