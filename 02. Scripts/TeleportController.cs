using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	private SteamVR_TrackedController trackedCtrl;

	private SteamVR_Controller.Device controller{
		get{
			return SteamVR_Controller.Input((int)trackedObj.index);
		}
	}

	private LineRenderer laser;
	private RaycastHit hit;
	private int floorLayer;

	private Transform tr;
	private Transform playerTr;

	void Awake(){
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		trackedCtrl = GetComponent<SteamVR_TrackedController>();
	
		laser = GetComponent<LineRenderer>();
		laser.enabled = false;

		tr = GetComponent<Transform>();
		playerTr = GameObject.Find("Player - HTCVIVE").GetComponent<Transform>();

		floorLayer = 1 << LayerMask.NameToLayer("FLOOR");
	}

	void OnEnable(){
		trackedCtrl.PadTouched += TrackPad;
		trackedCtrl.PadUntouched += ReleaseTrackPad;
		trackedCtrl.PadClicked += RayCastAtLaser;
	}

	void OnDisable(){
		trackedCtrl.PadTouched -= TrackPad;
		trackedCtrl.PadUntouched -= ReleaseTrackPad;
		trackedCtrl.PadClicked -= RayCastAtLaser;
	}

	void TrackPad(object sender, ClickedEventArgs e){
		controller.TriggerHapticPulse(2000);
		Debug.Log("Pad is touched");

		laser.enabled = true;
	}

	void ReleaseTrackPad(object sender, ClickedEventArgs e){
		laser.enabled = false;
	}

	void RayCastAtLaser(object sender, ClickedEventArgs e){
		if(laser.enabled){
			if(Physics.Raycast(tr.position, tr.forward, out hit, Mathf.Infinity, floorLayer)){
				MovePlayer(hit.point);
			}
		}
	}

	void MovePlayer(Vector3 pos){
		Vector3 movePos = new Vector3(pos.x, playerTr.position.y, pos.z);
		playerTr.position = movePos;
	}

}
