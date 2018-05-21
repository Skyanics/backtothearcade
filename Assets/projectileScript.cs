using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {

    public float attackDamage;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ENEMY")
        {
            other.gameObject.GetComponent<EnemyAI>().enemycurrentHealth -= attackDamage;
        }

        else
        {
            Destroy(this);
        }

    }

}
