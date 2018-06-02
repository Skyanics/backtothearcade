using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementTriggerScript : MonoBehaviour {

    public Animator anim;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pedestal")
        {
            anim.SetBool("openDoor", true);
        }
    }
}
