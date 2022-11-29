using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using System;
public class Enemy : MonoBehaviour
{
    private NavMeshAgent Guard;     //Reference to the NavMesh used for the enemy movement.


    private Transform Player;       //Reference to the player's location.

    public GameObject Form1;
    public GameObject Form2;
    private GameObject Chara;       //Reference to the player.
    public GameObject AttackSphere;
    public GameObject ColExp;

    //public Light SightLight;

    public GameObject[] PatrolPoints;

    private Vector3 PatrolTarget;
    private Vector3 BallBase;
    private Vector3 BallHit;


    public bool Triggered = false;  //Reference to if an object enters the sight of the enemy. Public as it will be used by other scripts.
    private bool PlayerSeen = false;
    public bool EyeTrig = false;    //Reference for the Eye AI. If the Eye sees the player, this is called.
    public bool RandomPath = false;
    private bool PatrolRange = false;
    private bool CanAttack = true;
    private bool Hunt = false;
    private bool Freeze = false;

    public float AttackRange = 1f;  //Reference to the attack range. Public for designing and tersting the range.
    private int Index = 0;

    public int Damage = 1;

    RaycastHit HitData;             //Reference Data from where the Raycast hits

    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        //Sets a Game Object to the Player Character.
        Chara = GameObject.FindGameObjectWithTag("Player");
        Player = Chara.transform;
        Guard = GetComponent<NavMeshAgent>();
        Anim = Form2.GetComponent<Animator>(); //Sets Animation to be played.

        Form1.SetActive(true);
        Form2.SetActive(false);


        Index = 0;

        PatrolTarget = new Vector3(PatrolPoints[Index].transform.position.x, transform.position.y, PatrolPoints[Index].transform.position.z);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Guard.remainingDistance <= 1)
        {
            if (PatrolRange == false)
            {

                if (RandomPath == true)
                {
                    //print(Index);
                    if (Random.Range(0, 2) == 0)
                    {
                         Next();
                    }
                    else
                    {

                         Back();

                    }
                }
                else
                {
                    Next();
                }
            }
        }

        if (Triggered == true)
        {
            //Casts a Raycast to see if the player is in sight.
            Physics.Raycast(transform.position, Chara.transform.position - transform.position, out HitData, 50);
            Debug.DrawRay(transform.position, Player.transform.position - transform.position);

            //if (HitData.collider.tag != null)
            //{
            //print("hit");
            //Checks what tag the collided object is.
            string tag = HitData.collider.tag;
            //}
            //Checks the distacne between the enemy and the player
            float HitDis = HitData.distance;

            //If the tag is "Player", begins to chase.
            if (tag == "Player")
            {
                if (PlayerSeen == false)
                {
                    print("AlertStart");
                    StopCoroutine(PlayerGone());
                    StartCoroutine(PlayerSpotted());
                }
                PlayerSeen = true;
                //SightLight.color = Color.red;

                if (Freeze == false)
                {
                    Guard.stoppingDistance = AttackRange;
                    Guard.SetDestination(Player.position);
                }

                if (HitDis <= AttackRange)
                {
                    if (CanAttack == true)
                    {
                        Anim.SetTrigger("Attack");
                        StartCoroutine(HitPlayer());
                        //print("Ghost");
                    }
                }

            }
            else
            {

                if (EyeTrig == false)
                {
                    if (PlayerSeen == true)
                    {
                        print("calm while trig");
                        StartCoroutine(PlayerGone());
                    }
                    //SightLight.color = Color.white;
                    Guard.stoppingDistance = 0f;
                    Guard.SetDestination(PatrolTarget);
                }
                PlayerSeen = false;
            }

            //If the player is in range, this is the attack logic.

        }
        else
        {

            if(EyeTrig == false && Hunt == false)
            {
                if (PlayerSeen == true)
                {
                    print("calm Trig");
                    StartCoroutine(PlayerGone());
                }
                PlayerSeen = false;
                //SightLight.color = Color.white;
                Guard.stoppingDistance = 0f;
                Guard.SetDestination(PatrolTarget);





                //Debug.Log("Hit");
            }

        }

        if(EyeTrig == true)
        {
            if (PlayerSeen == false)
            {
                print("Eye");
                StopCoroutine(PlayerGone());
                StartCoroutine(PlayerSpotted());
            }
            PlayerSeen = true;
            Guard.stoppingDistance = AttackRange;
            Guard.SetDestination(Player.position);
        }
        else
        {

            if (PlayerSeen == false && Hunt == false)
            {
                if (PlayerSeen == true)
                {
                    print("calm EYETrig");
                    StartCoroutine(PlayerGone());
                }

                //SightLight.color = Color.white;
                Guard.stoppingDistance = 0f;
                Guard.SetDestination(PatrolTarget);
            }
        }

        if (Hunt == true)
        {
            if (PlayerSeen == false)
            {
                StopCoroutine(PlayerGone());
                StartCoroutine(PlayerSpotted());
            }
            PlayerSeen = true;
            Guard.stoppingDistance = AttackRange;
            Guard.SetDestination(Player.position);
        }



    }

    IEnumerator PlayerSpotted()
    {
        Anim.SetTrigger("Reset");
        Form1.SetActive(false);
        Form2.SetActive(true);

        Guard.isStopped = true;
        yield return new WaitForSeconds(1f); //Time for Alert Animation
        Guard.isStopped = false;
        Anim.SetTrigger("Chasing");
        Hunt = true;

        yield return new WaitForSeconds(3f);
        Hunt = false;
    }

    IEnumerator PlayerGone()
    {
        if (Hunt == false)
        {

            Anim.SetTrigger("Calm");
            Guard.isStopped = true;

            print("calm");

            yield return new WaitForSeconds(0.8f); //Time for Revert Animation.
            Guard.isStopped = false;
            if (PlayerSeen == false)
            {
                Form1.SetActive(true);
                Form2.SetActive(false);
            }

        }
    }




//Sets index to next one.
    void Next()
    {
        Index = Index + 1;
        if (Index > (PatrolPoints.Length - 1))
        {
            Index = 0;
        }
        //Debug.Log("Hit");
        PatrolTarget = new Vector3(PatrolPoints[Index].transform.position.x, transform.position.y, PatrolPoints[Index].transform.position.z);
    }

    //Sets Index to previous one.
    void Back()
    {
        Index--;
        if (Index < 0)
        {
            Index = PatrolPoints.Length - 1;
        }
        PatrolTarget = new Vector3(PatrolPoints[Index].transform.position.x, transform.position.y, PatrolPoints[Index].transform.position.z);
    }

    IEnumerator HitPlayer()
    {
        
        BallBase = transform.position;
        CanAttack = false;
        
        Guard.isStopped = true;

        yield return new WaitForSeconds(0.4f); //TIme for Attack Animation

        AttackSphere.GetComponent<EnemyAttackBall>().Attack = true;
        GameObject Explosion = (GameObject)Instantiate(ColExp, AttackSphere.transform.position, AttackSphere.transform.rotation);
        yield return new WaitForSeconds(0.75f); //Time The Attack has to damage player.
        GameObject.Destroy(Explosion);
        AttackSphere.GetComponent<EnemyAttackBall>().Attack = false;



        Anim.SetTrigger("Chasing");

        Guard.isStopped = false;
        CanAttack = true;
    }
}
