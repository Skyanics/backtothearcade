using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalScript : MonoBehaviour {

    public Animator anim;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && anim.GetBool("isPushing") == false && Input.GetAxis("Horizontal") >= 0.1f || Input.GetAxis("Horizontal") <= -0.1f)
        {
            anim.SetBool("isPushing", true);
        }

        else
        {
            anim.SetBool("isPushing", false);
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            anim.SetBool("isPushing", false);
        }
    }
}
