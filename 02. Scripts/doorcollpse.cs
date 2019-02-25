using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorcollpse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag != "PLAYER")
            return;

        Debug.Log("collide!!");

        GetComponent<Rigidbody>().AddForce(Vector3.right * 10.0f, ForceMode.Impulse);
    }
}
