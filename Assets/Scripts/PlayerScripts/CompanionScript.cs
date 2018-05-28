using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionScript : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 2f;
    public Vector3 offsetLeft;
    public Vector3 offsetRight;
    private Vector3 currentOffset;
    private Vector3 desiredPosition;

    void FixedUpdate()
    {
        desiredPosition = target.position + currentOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        if (transform.rotation == Quaternion.LookRotation(Vector3.right))
        {
            currentOffset = offsetRight;
        }

        else
        {
            currentOffset = offsetLeft;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") <= -1)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.right);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") >= 1)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.left);
            Vector3 desiredPosition = target.position + offsetLeft;
        }
    }
}
