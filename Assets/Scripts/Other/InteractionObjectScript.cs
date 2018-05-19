using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjectScript : MonoBehaviour {

    public bool isPushPullObject;
    public bool isNear;
    public GameObject player;
    
	
	// Update is called once per frame
	void Update () {
       

        //PUSH OR PULL OBJECT
        if (isPushPullObject == true && isNear == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                transform.SetParent(player.transform);
                player.GetComponent<Player>().speed = 1.0f;
                player.GetComponent<Player>().jumpForce = 0.0f;
                player.GetComponent<Player>().isPulling = true;
                GetComponent<Rigidbody>().isKinematic = true;
                
            
                
            }

            else
            {
                transform.SetParent(null);
                player.GetComponent<Player>().speed = 5.0f;
                player.GetComponent<Player>().jumpForce = 10.0f;
                GetComponent<Rigidbody>().isKinematic = false;
                player.GetComponent<Player>().isPulling = false;
            }
        }
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isNear = false;
        }
    }
}
