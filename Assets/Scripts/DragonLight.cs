﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonLight : MonoBehaviour {

    public GameObject camera;
    public Light light;

    void Update()
    {
        if (camera.GetComponent<CameraFollow>().isZoomed == true)
        {
            light.intensity = 2.31f;
        }

        else
        {
            light.intensity = 0f;
        }
    }
}
