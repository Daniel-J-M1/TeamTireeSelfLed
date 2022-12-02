using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private GameObject UIElement;
    public bool Range = false;
    public float RotateSpeed = 5f;
    public float FloatHeight = 0.3f;
    public float FloatSpeed = 3f;
    private Vector3 StartPos;
    //public GameObject SecurityDoor;
    //private SecurityDoorScript Scripts;

    private void Start()
    {
        UIElement = GameObject.FindGameObjectWithTag("UIKeyCounter");
        StartPos = transform.position;
    }

    private void Update()
    {
        transform.Rotate(0, 6.0f * RotateSpeed * Time.deltaTime, 0);

        transform.position = new Vector3(transform.position.x, StartPos.y + (Mathf.Sin(Time.time * FloatSpeed) * FloatHeight), transform.position.z);

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
