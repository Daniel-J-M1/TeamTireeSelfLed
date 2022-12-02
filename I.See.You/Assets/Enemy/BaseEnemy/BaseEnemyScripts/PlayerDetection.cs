using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public GameObject Guard;
    private GameObject Player;

    private AudioSource Detected;

    RaycastHit HitData;             //Reference Data from where the Raycast hits


    // Start is called before the first frame update
    void Start()
    {
        Detected = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(transform.position, Player.transform.position - transform.position, out HitData, 50);
        Debug.DrawRay(transform.position, Player.transform.position - transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If Player enters trigger box, activate.
        if (other.gameObject.tag == "Player")
        {
            

            //Checks what tag the collided object is.
            string tag = HitData.collider.tag;


            if (tag == "Player")
            {
                Guard.GetComponent<Enemy>().Triggered = true;
                Detected.Play();
            }
        }

    }



    private void OnTriggerExit(Collider other)
    {
        //If Player enters trigger box, activate.
        if (other.gameObject.tag == "Player")
        {

            Guard.GetComponent<Enemy>().Triggered = false;

        }

    }


}
