using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsMono : MonoBehaviour {

    [Header("Health & Mana")]
    public float maxHealth = 100f;
    public float curHealth;
    public float maxMana = 100f;
    public float curMana;
    public Image healthSlider;
    public Image manaSlider;

    [Header("Positions")]
    public Vector3 playerPos;
    public Vector3 cameraPos;
    public Vector3 butterflyPos;

    [Header("Abilities")]
    public float manaAttackChargeNeeded = 40f;
    public float manaAttackCharge;
    public bool pickUpHealth;
    public bool pickUpMana;

    [Header("FollowObjects")]
    public GameObject camera;
    public GameObject butterfly;

    void Update () {

        playerPos = transform.position;
        cameraPos = camera.transform.position;
        butterflyPos = butterfly.transform.position;

        healthSlider.fillAmount = curHealth / maxHealth;
        manaSlider.fillAmount = curMana / maxMana;



        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curMana > maxMana)
        {
            curMana = maxMana;
        }

        if (curHealth <= 0)
        {
            Debug.Log("rip");
        }

	}
}
