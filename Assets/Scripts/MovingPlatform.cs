using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public GameObject player;
    public Transform farEnd;
    private Vector3 frometh;
    private Vector3 untoeth;
    public float secondsForOneLength = 20f;

    void Start()
    {
        frometh = transform.position;
        untoeth = farEnd.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(frometh, untoeth,
         Mathf.SmoothStep(0f, 1f,
          Mathf.PingPong(Time.time / secondsForOneLength, 1f)
        ));
    }

    void OnTriggerEnter()
    {
        player.transform.SetParent(this.transform);
    }

    void OnTriggerExit()
    {
        player.transform.SetParent(null);
    }
}
