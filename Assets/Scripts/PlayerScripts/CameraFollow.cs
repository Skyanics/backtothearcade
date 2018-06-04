using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 2f;
    public Vector3 offset;
    public Vector3 zoomedOffset;
    public bool isZoomed = false;

	void FixedUpdate () {

        Vector3 desiredPosition = target.position + offset;
        Vector3 zoomedPosition = target.position + zoomedOffset;

        if (!isZoomed)
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

        else
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, zoomedPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

	}
}
