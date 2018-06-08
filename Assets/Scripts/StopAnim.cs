using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnim : MonoBehaviour {

    public Animator anim;
    public ParticleSystem particle;
    public Player player;

    void Effect()
    {
        particle.Play();
    }

    void StopSpAtkAnim()
    {
        anim.SetBool("isSpecialAttack", false);
        
    }

    void Jump()
    {
        player.verticalVelocity = player.jumpForce;
    }
}
