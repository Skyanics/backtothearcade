using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBuff : MonoBehaviour {

    public bool isMana;
    public bool isHealth;
    public PlayerStatsMono stats;

    private float chargeValue = 25f;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isMana == true)
        {
            stats.curMana += chargeValue;
            Destroy(this.gameObject);
        }

        if (other.tag == "Player" && isHealth == true)
        {
            stats.curHealth += stats.maxHealth - stats.curHealth;
            Destroy(this.gameObject);
        }

    }
}
