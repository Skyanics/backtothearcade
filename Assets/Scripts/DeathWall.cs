using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour {

	public GameObject spawnpos;
    private GameObject player;
    public Animator anim;
 
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
            player = other.transform.gameObject;
            StartCoroutine(drownSequence());
     
			
		}
	}

    IEnumerator drownSequence()
    {
        anim.SetBool("isDrowning", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("isDrowning", false);
        player.transform.position = spawnpos.transform.position;
    }
}
