using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenFlame : MonoBehaviour
{
    public GameObject fire;
    public GameObject explosion;

    public float height;
    private float camAngle;

    private GameObject player;// = GameObject.Find("Player - MRCP");
    private MoveCtrl player_move_script;// = player.GetComponent<MoveCtrl>();

    private void Start()
    {
        player = GameObject.Find("Player - MRCP");
        player_move_script = player.GetComponent<MoveCtrl>();
        //fire.SetActive(false);
    }

    private void OnTriggerEnter(Collider coll)
    {
        Debug.Log("collide!!");
        if (coll.tag != "PLAYER")
            return;
        
        player_move_script.moveSpeed = 0.0f;

        // Transform cameraTr = GameObject.Find("MixedRealityCamera").transform;//<Transform>();
        // Vector3 playerLocation = cameraTr.position;
        
        // Debug.Log("euler: " + Camera.main.transform.localEulerAngles.y);
        // camAngle = Camera.main.transform.localEulerAngles.y;

        // //Vector3 direction = new Vector3(Mathf.Sin(camAngle), height, Mathf.Cos(camAngle));
        // Vector3 direction = new Vector3(0, height, 0.7f);
        
        // Instantiate(fire, new Vector3(playerLocation.x, 0.0f, playerLocation.z) + direction, new Quaternion(0, 0, 0, 0));
        Vector3 playerLocation = coll.GetComponent<Transform>().position;
        Debug.Log(playerLocation);

        Instantiate(explosion, playerLocation + new Vector3(0.0f, height, 0.7f), new Quaternion(0, 0, 0, 0));
        Instantiate(fire, playerLocation + new Vector3(0.0f, height, 0.7f), new Quaternion(0, 0, 0, 0));
    }
}
