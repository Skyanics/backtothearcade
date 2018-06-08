using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEventTrigger : MonoBehaviour {

    public GameObject camera;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            camera.GetComponent<CameraFollow>().isZoomed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            camera.GetComponent<CameraFollow>().isZoomed = false;
        }
    }
}
