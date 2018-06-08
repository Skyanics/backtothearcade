using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailDamage : MonoBehaviour {

    public PlayerStatsMono stats;
    public float damage = 25f;
    public bool damageDone = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && damageDone == false)
        {
            stats = other.GetComponent<PlayerStatsMono>();
            stats.curHealth -= damage;
            damageDone = true;
        }
    }
}
