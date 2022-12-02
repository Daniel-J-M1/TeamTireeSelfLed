using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelRotation : MonoBehaviour
{
    private CharacterController Control;    //References the player character

    // Start is called before the first frame update
    void Start()
    {
        Control = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //Gets movement input.
        move = Vector3.ClampMagnitude(move, 1); //Sets the movement speed to be the same no matter the direction.


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //Gets movement input.
            //move = Vector3.ClampMagnitude(move, 1); //Sets the movement speed to be the same no matter the direction.
            transform.rotation = Quaternion.LookRotation(move);
        }
    }
}
