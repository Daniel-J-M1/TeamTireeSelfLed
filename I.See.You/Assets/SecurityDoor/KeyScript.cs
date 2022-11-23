using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private GameObject UIElement;
    public bool Range = false;
    //public GameObject SecurityDoor;
    //private SecurityDoorScript Scripts;

    private void Start()
    {
        UIElement = GameObject.FindGameObjectWithTag("UIKeyCounter");
    }

    private void Update()
    {

        if (Range == true)
        {
            //Scripts = SecurityDoor.GetComponent<SecurityDoorScript>();

            //Scripts.KeyFound();
            UIElement.GetComponent<KeyCounter>().CounterDown();

            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        print("Key");
        if (other.gameObject.tag == "Player")
        {
            
            Range = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Key");
            Range = false;
        }
    }

}
