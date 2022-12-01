using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBall : MonoBehaviour
{

    private GameObject Player;       //Reference to the player.
    
    public bool Attack = false;
    private bool PlayerRange = false;

    public int Damage = 1;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update


    private void FixedUpdate()
    {
        if (Attack == true && PlayerRange == true)
        {
            
            Player.GetComponent<PlayerHealth>().DamagePlayer(Damage);
            
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //print("Attack");
            PlayerRange = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Attack");
            PlayerRange = false;
        }
    }
}
