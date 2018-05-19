using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AuraAPI;

public class StartingLight : MonoBehaviour {

    public Light auraLight01;
    public Light auraLight02;

	void Start () {
        auraLight01.GetComponent<AuraLight>().enabled = true;
        auraLight02.GetComponent<AuraLight>().enabled = true;

    }

}
