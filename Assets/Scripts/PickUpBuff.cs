using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBuff : MonoBehaviour {

    public bool isMana;
    public bool isHealth;
    public PlayerStatsMono stats;
    public AudioSource aud;
    public AudioClip mana;
    public AudioClip health;

    private float chargeValue = 25f;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isMana == true && GetComponent<Renderer>().enabled == true)
        {
            stats.curMana += chargeValue;
            aud.PlayOneShot(mana);
            GetComponent<Renderer>().enabled = false;
            GetComponent<ParticleSystem>().Stop();

        }

        if (other.tag == "Player" && isHealth == true && GetComponent<Renderer>().enabled == true)
        {
            stats.curHealth += stats.maxHealth - stats.curHealth;
            aud.PlayOneShot(health);
            GetComponent<Renderer>().enabled = false;
            GetComponent<ParticleSystem>().Stop();

        }

    }
}
