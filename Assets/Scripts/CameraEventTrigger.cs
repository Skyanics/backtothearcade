using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraEventTrigger : MonoBehaviour {

    public GameObject camera;
    public bool fixDoF;
    public PostProcessingProfile postProf;

    void Start()
    {
        postProf = camera.GetComponent<PostProcessingBehaviour>().profile;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(fixDoF = true)
            {
                var dof = postProf.depthOfField.settings;
                dof.focusDistance = 30;
            }
            
            camera.GetComponent<CameraFollow>().isZoomed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (fixDoF = true)
            {
                var dof = postProf.depthOfField.settings;
                dof.focusDistance = 13;
            }
            camera.GetComponent<CameraFollow>().isZoomed = false;
        }
    }
}
