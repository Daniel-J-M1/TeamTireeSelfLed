using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController Control;    //References the player character
    private float PlayerSpeed;              //Speed of the player
    public float Walking = 2f;              //Walking Speed
    public float Running = 4f;              //Running Speed
    private float Ground;
    public float SpeedBoost = 2f;
    public bool Invulnerable = false;
    public Material[] EnemyChange;
    private GameObject[] Guard;     //Array for the guard assets
    private MeshRenderer Meshs;

    // Start is called before the first frame update
    void Start()
    {
        //Sets player controller.
        Control = gameObject.AddComponent<CharacterController>();
        Guard = GameObject.FindGameObjectsWithTag("Enemy");
        Ground = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Determines of the player is running or not.
        if (Input.GetKey("left shift"))
        {
            if (Invulnerable == false)
            {
                PlayerSpeed = Running;
            }
            else
            {
                PlayerSpeed = Running * SpeedBoost;
            }
        }
        else
        {
            if (Invulnerable == false)
            {
                PlayerSpeed = Walking;
            }
            else
            {
                PlayerSpeed = Walking * SpeedBoost;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (var I in Guard)
            {
                Meshs = I.GetComponent<MeshRenderer>();
                Meshs.material = EnemyChange[1];
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var I in Guard)
            {
                Meshs = I.GetComponent<MeshRenderer>();
                Meshs.material = EnemyChange[0];
            }
        }



        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //Gets movement input.
        move = Vector3.ClampMagnitude(move, 1); //Sets the movement speed to be the same no matter the direction.
        

        Control.Move(move * Time.deltaTime * PlayerSpeed); //The movement speed of the player
        transform.position = new Vector3(transform.position.x, Ground, transform.position.z);
    }
}
