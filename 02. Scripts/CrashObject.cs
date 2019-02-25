using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashObject : MonoBehaviour {
    // 문 관련 변수
    public DoorObject DoorLeft;
    public DoorObject DoorRight;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("PLAYER"))
        {
            Debug.Log("Crash!!!!");
            DoorLeft.DoorSwitch = true;
            DoorRight.DoorSwitch = true;
        }
    }
}
