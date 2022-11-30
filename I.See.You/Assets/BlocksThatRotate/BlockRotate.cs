using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotate : MonoBehaviour    
{
    public GameObject Block;            //References the block in question
    private GameObject Player;
    public GameObject RightArrow;
    public GameObject LeftArrow;
    public GameObject[] RotBlocksAttached;

    public Material CanTurn;
    public Material CannotTurn;


    private AudioSource Rot;

    private Quaternion TargetRot;

    private Quaternion BlockRot;

    private bool Triggered = false;     //Controls the input.
    private bool TurningLeft = false;
    private bool TurningRight = false;
    private bool StartLeft = false;
    private bool StartRight = false;

    public float RotateTime = 1f;     //Controls time between inputs.
    public float LimitRight = 1f;
    public float LimitLeft = 1f;
    public float MaxRight;
    public float MaxLeft;
    public float TurningRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Sets cursor to be locked to the window and to be shown.
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        BlockRot = transform.rotation;
        TurningRot = transform.rotation.eulerAngles.y;
        //print(TurningRot);
        Player = GameObject.FindGameObjectWithTag("Player");
        Rot = GetComponent<AudioSource>();
    }

    //Checks if the mouse cursor is hovering over the object.
    private void OnMouseOver()
    {
        //Checks if the left mouse button is pressed.
        if (Input.GetMouseButton(0) && Triggered == false && LimitLeft > 0 && LimitLeft < (MaxLeft+1) && Player.GetComponent<RotationSkillCounter>().RotCounter > 0)
        {
            Triggered = true;
            TurningLeft = true;
            //Debug.Log("Left");
            LimitLeft = LimitLeft - 1;
            LimitRight = LimitRight + 1;

            //StopCoroutine(Player.GetComponent<RotationSkillCounter>().RotSkill());
            Player.GetComponent<RotationSkillCounter>().RotCounter = Player.GetComponent<RotationSkillCounter>().RotCounter - 1;
            //StartCoroutine(Player.GetComponent<RotationSkillCounter>().RotSkill());

            Rot.Play();

            print(TurningRot);
            BlockRot = Quaternion.Euler(BlockRot.eulerAngles.x, TurningRot, BlockRot.eulerAngles.z);
        }

        //Checks if the Right mouse button is pressed.
        if (Input.GetMouseButton(1) && Triggered == false && LimitRight > 0 && LimitRight < (MaxRight + 1) && Player.GetComponent<RotationSkillCounter>().RotCounter > 0)
        {
            Triggered = true;
            TurningRight = true;
            //Debug.Log("Right");
            LimitLeft = LimitLeft + 1;
            LimitRight = LimitRight - 1;

            //StopCoroutine(Player.GetComponent<RotationSkillCounter>().RotSkill());
            Player.GetComponent<RotationSkillCounter>().RotCounter = Player.GetComponent<RotationSkillCounter>().RotCounter - 1;
            //StartCoroutine(Player.GetComponent<RotationSkillCounter>().RotSkill());

            Rot.Play();

            BlockRot = Quaternion.Euler(BlockRot.eulerAngles.x, TurningRot, BlockRot.eulerAngles.z);

            //BlockRot = Quaternion.Euler(BlockRot.eulerAngles.x, (BlockRot.eulerAngles.y + 90), BlockRot.eulerAngles.z);
        }

        if (LimitRight > 0 && LimitRight < (MaxRight + 1))
        {
            RightArrow.GetComponent<MeshRenderer>().material = CanTurn;
        }
        else
        {
            RightArrow.GetComponent<MeshRenderer>().material = CannotTurn;
        }

        if (LimitLeft > 0 && LimitLeft < (MaxLeft + 1))
        {
            LeftArrow.GetComponent<MeshRenderer>().material = CanTurn;
        }
        else
        {
            LeftArrow.GetComponent<MeshRenderer>().material = CannotTurn;
        }
    }

    public void Update()
    {
        if (TurningLeft == true)
        {
            //Starts Coroutine for rotating the block to the left.
            StartCoroutine(LeftRotate());

            
            foreach (var I in RotBlocksAttached)
            {
                I.GetComponent<BlockRotate>().TurningLeft = true;
            }
            

        }
        if (TurningRight == true)
        {
            //Starts Coroutine for rotating the block to the right.
            StartCoroutine(RightRotate());

            
            foreach (var I in RotBlocksAttached)
            {
                I.GetComponent<BlockRotate>().TurningRight = true;
            }
        }

        if (StartLeft == true)
        {
            TargetRot = Quaternion.Euler(transform.rotation.eulerAngles.x, TurningRot, transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot, 3.5f * Time.deltaTime);

        }
        else if(StartRight == true)
        {
            TargetRot = Quaternion.Euler(transform.rotation.eulerAngles.x, TurningRot, transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot, 3.5f * Time.deltaTime);
        }




    }

    IEnumerator LeftRotate()
    {

        StartLeft = true;

        ////Below is an alternative way to rotate the block.

        if (TurningRot == -180)
        {
            TurningRot = 180 - 90;
        }
        else
        {
            TurningRot = TurningRot - 90;
        }



        //print(BlockRot.y);

        //Block.transform.Rotate(0, -90, 0); //A shap rotation of the block.
        //transform.rotation = Quaternion.Slerp(transform.rotation, BlockRot, RotateTime);

        TurningLeft = false;
        //Checks if the routine has been triggered, stops repeated input.

        yield return new WaitForSeconds(RotateTime);
        Triggered = false;
        StartLeft = false;
        
    }

    IEnumerator RightRotate()
    {

        StartRight = true;

        if (TurningRot == 180)
        {
            TurningRot = -180 + 90;
        }
        else
        {
            TurningRot = TurningRot + 90;
        }

        ////Below is an alternative way to rotate the block.


        //print(BlockRot.y);

        //Block.transform.Rotate(0, 90, 0); //A shap rotation of the block.
        //transform.rotation = Quaternion.Slerp(transform.rotation, BlockRot, 6 * Time.deltaTime);

        TurningRight = false;
        //Checks if the routine has been triggered, stops repeated input.

        yield return new WaitForSeconds(RotateTime);
        Triggered = false;
        StartRight = false;
        
    }
}
