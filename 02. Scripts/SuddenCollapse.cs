using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenCollapse : MonoBehaviour {

    private GameObject[] doors;
    public GameObject expEffect;

    private Quaternion curRot;
    private Vector3 angle;
    private Vector3 delta;

    //Rigidbody doorPhysics;

    // Use this for initialization
    void Start()
    {
        doors = GameObject.FindGameObjectsWithTag("FRONT_DOOR");
        delta = new Vector3(1.0f, 0.0f, 0.0f);

        Transform curTr = doors[0].GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider coll){
        if (coll.tag != "PLAYER")
            return;

        Debug.Log("collide!!");
       
        doors[0].GetComponent<Rigidbody>().AddForce(Vector3.right * 10.0f, ForceMode.Impulse);
    }
}
