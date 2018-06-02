using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalScript : MonoBehaviour {

    public Animator anim;

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player" && anim.GetBool("isPushing") == false)
        {
            anim.SetBool("isPushing", true);
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
