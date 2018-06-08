﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBattleScript : MonoBehaviour {

    public bool playerEnteredArea = false;
    public bool playerDeath = false;
    public GameObject player;
    public Transform headLocation;
    [SerializeField]private int attack;
    [SerializeField]private Animator anim;
    public tailDamage tail;
    [SerializeField]private float curDamage;

    //boss stats
    public float BossHealth = 5000;
    public Image healthbar;
    public GameObject body;
    public Color finalcolor;

    //rocks
    public Transform rockSpawn1;
    public Transform rockSpawn2;
    public Transform rockSpawn3;
    public GameObject projectile;
    public GameObject projectile0;
    public GameObject projectile1;
    public GameObject projectile2;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        healthbar.fillAmount = BossHealth / 5000;
        Debug.Log(Vector3.Distance(headLocation.position, player.transform.position));


        if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("Fire1"))
        {
           if(Vector3.Distance(headLocation.position, player.transform.position) >= 4 || Vector3.Distance(headLocation.position, player.transform.position) <= 7 ) 
            BossHealth -= curDamage;


        }
    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            StartCoroutine(BossBattle());
            playerEnteredArea = true;
        }
    }

    IEnumerator BossBattle()
    {
        while (playerEnteredArea == true && !playerDeath)
        {
            attack = Random.Range(0, 5);
            yield return new WaitForSeconds(2);
            if(attack == 0 || attack == 3)
            {
                anim.SetBool("tailSweep", true);
                yield return new WaitForSeconds(2);
                anim.SetBool("tailSweep", false);
            }

            if (attack == 1 || attack == 4)
            {
                anim.SetBool("jumpAttack", true);
                yield return new WaitForSeconds(2);
                anim.SetBool("jumpAttack", false);
            }

            if (attack == 2 || attack == 5)
            {
                anim.SetBool("biteAttack", true);
                yield return new WaitForSeconds(5.8f);
                anim.SetBool("biteAttack", false);
            }

            
        }

    }


    public void DamagePhaseStart()
    {
        curDamage = player.GetComponent<Player>().playerDamage;
        body.GetComponent<Renderer>().material.SetColor("_EmissionColor", finalcolor);
    }

    public void DamagePhaseEnd()
    {
        curDamage = 0f;
        body.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
    }

    public void DamageToPlayerWithTail()
    {
        tail.damageDone = false;
    }

    public void SpawnRocks()
    {
        projectile0 = Instantiate(projectile, rockSpawn1);
        projectile1 = Instantiate(projectile, rockSpawn2);
        projectile2 = Instantiate(projectile, rockSpawn3);
        Destroy(projectile0, 5);
        Destroy(projectile1, 5);
        Destroy(projectile2, 5);
    }
}