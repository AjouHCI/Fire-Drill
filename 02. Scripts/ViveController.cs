using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveController : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	private MoveCtrl parentScript;
	
	private SteamVR_Controller.Device controller{
		get{
			return SteamVR_Controller.Input((int)trackedObj.index);
		}
	}

	void Awake(){
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	// Use this for initialization
	void Start () {
		parentScript = this.transform.parent.GetComponent<MoveCtrl>();
	}
	
	// Update is called once per frame
	void Update () {
		if(controller == null){
			Debug.Log("Controller is not detected");
			return;
		}

		if(controller.GetHairTriggerDown()){
			Debug.Log("Trigger " + controller.index + " is pressed");
		}

		if(controller.GetHairTriggerUp()){
			Debug.Log("Trigger " + controller.index + " is unpressed");
		}

		if (controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)){
			Debug.Log(controller.index + " App button pressed");
		}

		if (controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip)){
			Debug.Log(controller.index + " Grip button unpressed");

			Debug.Log("Par: " + parentScript.moveSpeed);
			if(parentScript.moveSpeed == 0)
				parentScript.moveSpeed = 1.0f;
			else 
				parentScript.moveSpeed = 0.0f;
		}

		if (controller.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)){
			Vector2 pad = controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
			Debug.Log("TouchPad = " + controller.index + " " + pad);
		}

	}
}
