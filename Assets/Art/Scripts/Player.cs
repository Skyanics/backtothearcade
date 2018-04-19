using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody rig;
    public float speed;
    public float jumpspeed;

	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        var playerJump = Input.GetKeyDown(KeyCode.Space);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rig.velocity = movement * speed;
    }
}
