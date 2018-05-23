using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    //whichEnemy
    public bool isRegular;
    public bool isHeavy;

    //enemyVariables
    [SerializeField]
    private float enemyHealth;
    public float enemycurrentHealth;
    public Image healthbar;
    public int enemyAtk;
    [SerializeField]
    private string name;
    //public GameObject enemyMesh;

    //patrol variables
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    //chase variables
    public Transform player;
    [SerializeField]
    private int MaxChaseDist;
    [SerializeField]
    private int MaxAttackDist;
    [SerializeField]
    private int MinDist;

    //Display
    //public TextMesh healthBar;

    //Player Script
    public PlayerStatsMono playerStats;
    public bool isAttacking;

    //raycasting
    public float maxRayDistance = 25;
    [SerializeField]
    private bool playerSighted = false;
    public Vector3 curDirection;
    public Text enemyName;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        if (Vector3.Distance(transform.position, player.position) >= MaxChaseDist)
        {
            GotoNextPoint();
        }

        if (isRegular == true)
        {
            enemyHealth = 100;
            enemycurrentHealth = 100;
            enemyAtk = 15;
            MaxChaseDist = 10;
            MaxAttackDist = 6;
            MinDist = 5;
            name = "Rat Knight";
            // enemyMesh.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (isHeavy == true)
        {
            enemyHealth = 150;
            enemycurrentHealth = 150;
            enemyAtk = 20;
            MaxChaseDist = 10;
            MaxAttackDist = 6;
            MinDist = 5;
            name = "Rat Brute";
            //  enemyMesh.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Ray ray = new Ray(transform.position, forward);
        RaycastHit hit;
        

        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            Debug.DrawRay(transform.position, forward, Color.red);
            if (hit.transform.tag == "Player")
            {
                playerSighted = true;
            }

            else
            {
                playerSighted = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        enemyName.text = name;
        //healthBar.text = text;

        healthbar.fillAmount = enemycurrentHealth / enemyHealth;

        if (Vector3.Distance(transform.position, player.position) <= MaxChaseDist && Vector3.Distance(transform.position, player.position) >= MinDist)
        {
            agent.destination = player.transform.position;
            //Debug.Log(Vector3.Distance(transform.position, player.position));
            transform.LookAt(new Vector3(agent.destination.x, transform.position.y, agent.destination.z));

        }

        else if (Vector3.Distance(transform.position, player.position) >= MaxChaseDist && isAttacking)
        {
            agent.destination = points[destPoint].position;
            isAttacking = false;
            transform.LookAt(new Vector3(agent.destination.x, transform.position.y, agent.destination.z));
        }

        else
        {
            agent.destination = transform.position;
            transform.LookAt(new Vector3(agent.destination.x, transform.position.y, agent.destination.z));

        }



        if (Vector3.Distance(transform.position, player.position) <= MaxAttackDist && Vector3.Distance(transform.position, player.position) >= MinDist)
        {
           // Debug.Log("Attacked");
            if (isAttacking == false && playerSighted == true)
            {
                StartCoroutine(Attack());
            }
            else
            {
                StopCoroutine(Attack());
            }
        }



        if (Vector3.Distance(transform.position, player.position) >= MaxChaseDist)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }

        if (enemycurrentHealth <= 0)
        {
            isAttacking = false;
            Destroy(this.gameObject);

        }

    }

        IEnumerator Attack()
        {
            while (playerStats.curHealth > 0 && Vector3.Distance(transform.position, player.position) <= MaxAttackDist)
            {
            Debug.Log("attack");
                isAttacking = true;
                playerStats.curHealth -= enemyAtk;
                playerStats.healthSlider.fillAmount -= (float)enemyAtk / 100;
                yield return new WaitForSeconds(2);

            }



        }

    }
