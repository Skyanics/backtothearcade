using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour {

	public GameObject spawnpos;
 
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.gameObject.transform.position = spawnpos.transform.position;
		}
	}
}
