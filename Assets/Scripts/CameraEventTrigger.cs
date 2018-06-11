using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEventTrigger : MonoBehaviour {

    public GameObject camera;
<<<<<<< HEAD
    public bool fixDoF;
    public PostProcessingProfile postProf;

    public bool dragon;
    public AudioSource aud;

    void Start()
    {
        postProf = camera.GetComponent<PostProcessingBehaviour>().profile;
    }
=======
>>>>>>> parent of e4061298... Stuff enzo kek

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
<<<<<<< HEAD
            if (dragon)
            {
                aud.PlayOneShot(aud.clip);
            }

            if(fixDoF == true)
            {
                var dof = postProf.depthOfField.settings;
                dof.focusDistance = 30;
            }
            
=======
>>>>>>> parent of e4061298... Stuff enzo kek
            camera.GetComponent<CameraFollow>().isZoomed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
<<<<<<< HEAD
            if (fixDoF == true)
            {
                var dof = postProf.depthOfField.settings;
                dof.focusDistance = 13;
            }
=======
>>>>>>> parent of e4061298... Stuff enzo kek
            camera.GetComponent<CameraFollow>().isZoomed = false;
        }
    }
}
