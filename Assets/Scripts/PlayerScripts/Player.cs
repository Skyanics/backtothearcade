using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public PlayerStatsMono playerStats;
    public float speed = 5.0f;
    public float verticalVelocity;
    public float Gravity;
    public float jumpForce = 10.0f;
    public bool isPulling;
    public ParticleSystem atkParticle;

    private Quaternion rot;
    private Vector3 moveVector;
    private Vector3 lastMove;
    public GameObject spawnpos;

    public Animator anim;

    public float maxRayDistance = 5f;
    public float playerDamage = 20f;

    private bool wallJumped = false;

    private float attackCharge;
    public Light playerLight;


    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speed;

        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("isRunning", true);
        }

        else {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isAttacking", true);
            atkParticle.Play();
            PlayerAttack();
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetButton("Fire1") && playerStats.curMana == playerStats.maxMana)
        {
            attackCharge += Time.deltaTime;
        }

        if (attackCharge >= 1)
        {
            PlayerChargedAttack(transform.position, 5, 100);
            attackCharge = 0;
            playerStats.curMana -= playerStats.maxMana;
            playerLight.intensity = Mathf.Lerp(1f, 5f, 5f);
            anim.SetBool("isSpecialAttack", true);
        }

        if (Input.GetKeyUp(KeyCode.Q) || Input.GetButtonUp("Fire1"))
        {
            attackCharge = 0;
            playerLight.intensity = Mathf.Lerp(5f, 1f, 5f);
            anim.SetBool("isSpecialAttack", false);
        }


        else
        {
            anim.SetBool("isAttacking", false);
        }

        if (controller.isGrounded)
        {
            verticalVelocity = -1;
            wallJumped = false;
            anim.SetBool("isJumping", false);
            anim.SetBool("isGrounded", true);


            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {
                anim.SetBool("isGrounded", false);
                anim.SetBool("isJumping", true);
                verticalVelocity = jumpForce;
            }
        }

        else if (wallJumped == true)
        {
            moveVector = lastMove;
            verticalVelocity -= Gravity * Time.deltaTime;
        }

        else
        {
            verticalVelocity -= Gravity * Time.deltaTime;
        }

        moveVector.y = 0;
        moveVector.Normalize();
        moveVector *= speed;
        moveVector.y = verticalVelocity;

        controller.Move(moveVector * Time.deltaTime);
        lastMove = moveVector;

        var partrot = atkParticle.rotationOverLifetime;
        partrot.z = 0;

        if (rot == Quaternion.LookRotation(Vector3.left))
        {
            partrot.z = 15;
        }

        else
        {
            partrot.z = -15;
        }

 

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") <= -0.01f)
        {
            rot = Quaternion.LookRotation(Vector3.left);
            
            
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") >= 0.01f)
        {
            rot = Quaternion.LookRotation(Vector3.right);
        }

        if (!isPulling)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);
        }

        if (transform.position.z != -6.9)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -6.9f);
        }

        if (playerStats.curHealth <= 0)
        {
            anim.SetBool("Death", true);
            StartCoroutine(Death()); 
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(5);
        transform.position = spawnpos.transform.position;
        playerStats.curHealth = playerStats.maxHealth;
        anim.SetBool("Death", false);
        StopCoroutine(Death());
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!controller.isGrounded && hit.normal.y < 0.1f)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {
                Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
                verticalVelocity = jumpForce;
                moveVector = hit.normal * speed;
                rot = Quaternion.LookRotation(hit.normal);
                wallJumped = true;
            }
        }

    }

    void PlayerAttack()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Ray ray = new Ray(transform.position, forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            if (hit.transform.tag == "Enemy")
            {
                Debug.DrawRay(transform.position, Vector3.left, Color.red);
                hit.transform.GetComponent<EnemyAI>().enemycurrentHealth -= playerDamage;
                Vector3 pushBackAmount = new Vector3(1.5f, 0.5f, 0);
                hit.transform.position = Vector3.Lerp(hit.transform.position, hit.transform.position + pushBackAmount, 0.5f);
            }
        }
    }

    void PlayerChargedAttack(Vector3 location, float radius, float damage)
    {
        Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
        foreach (Collider col in objectsInRange)
        {
            EnemyAI enemy = col.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                // linear falloff of effect
                float proximity = (location - enemy.transform.position).magnitude;
                float effect = 1 - (proximity / radius);

                enemy.enemycurrentHealth -= damage * effect;
            }
        }

       

    }
}
