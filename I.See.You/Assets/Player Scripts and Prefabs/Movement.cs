using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController Control;    //References the player character
    private float PlayerSpeed;              //Speed of the player
    public float Walking = 2f;              //Walking Speed
    public float Running = 4f;              //Running Speed

    // Start is called before the first frame update
    void Start()
    {
        //Sets player controller.
        Control = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Determines of the player is running or not.
        if (Input.GetKey("left shift"))
        {
            PlayerSpeed = Running;
        }
        else
        {
            PlayerSpeed = Walking;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //Gets movement input.
        move = Vector3.ClampMagnitude(move, 1); //Sets the movement speed to be the same no matter the direction.

        Control.Move(move * Time.deltaTime * PlayerSpeed); //The movement speed of the player
    }
}
