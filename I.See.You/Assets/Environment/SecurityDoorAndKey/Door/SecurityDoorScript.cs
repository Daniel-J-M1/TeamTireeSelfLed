using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityDoorScript : MonoBehaviour
{
    public GameObject[] Keys;

    private AudioSource DoorOpen;

    private float Control;

    //private bool KeyCollected = false;
    public bool Range = false;


    private void Start()
    {
        DoorOpen = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Range == true && Input.GetKeyDown(KeyCode.Q) && Control == 0)
        {
            DoorOpen.Play();
            StartCoroutine(DoorDestroy());

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            print("Door");
            Range = true;
        }

        Control = Keys.Length;
        foreach (var i in Keys)
        {
            if (i == null)
            {
                Control--;
            }
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Door");
            Range = false;
        }
    }

    IEnumerator DoorDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }




    //public void KeyFound()
    //{
    //    KeyCollected = true;
    //}



}
