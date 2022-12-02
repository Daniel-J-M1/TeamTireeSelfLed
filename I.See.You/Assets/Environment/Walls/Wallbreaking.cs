using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallbreaking : MonoBehaviour
{
    RaycastHit HitData;             //Reference Data from where the Raycast hits

    private GameObject WallBreakers;
    //public GameObject Wall;


    public float WallDestroyDis = 2;

    public LayerMask BreakWall;

    private bool BreakerEnters = false;

    private void Update()
    {
        //if()
        if(BreakerEnters == true)
        {




            Physics.Raycast(transform.position, WallBreakers.transform.position - transform.position, out HitData, 10, ~BreakWall);

            Debug.DrawRay(transform.position, WallBreakers.transform.position - transform.position);

            //Checks what tag the collided object is.
            string tag = HitData.collider.tag;

            //Checks the distacne between the enemy and the player
            float HitDis = HitData.distance;


            //print(tag);
            //print(HitDis);


            //If the tag is "Player", begins to chase.
            //if (tag == "WallEnemy")
            //{
                if (HitDis <= WallDestroyDis)
                {
                    Destroy(gameObject);
                }



                //print("wall");
            //}
        }
    }



    private void OnTriggerEnter(Collider other)
    {

        
        
        //print("wall");
        //If Player leaves trigger box, deactivate.
        if (other.gameObject.tag == "WallEnemy")
        {
            WallBreakers = other.gameObject;

            BreakerEnters = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {



        //print("wall");
        //If Player leaves trigger box, deactivate.
        if (other.gameObject.tag == "WallEnemy")
        {

            BreakerEnters = false;
        }

    }
}
