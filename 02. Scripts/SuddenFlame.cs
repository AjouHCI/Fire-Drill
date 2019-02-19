using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenFlame : MonoBehaviour
{
    public GameObject fire;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider coll)
    {
        Debug.Log("collide!!");
        if (coll.tag != "PLAYER")
            return;

        Vector3 playerLocation = coll.GetComponent<Transform>().position;
        Debug.Log(playerLocation);

        Instantiate(fire, playerLocation + new Vector3(0.0f, 3.0f, 1.5f), new Quaternion(0, 0, 0, 0));
    }
}
