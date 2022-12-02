using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransparency : MonoBehaviour
{
    //public GameObject Wall1;
    //public GameObject Wall2;
    //
    private GameObject Player;
    public GameObject Wall;
    private GameObject PrevWall;
    //private GameObject WallCheck;

    //private GameObject[] AttachedWalls; 

    public Material TranMat;
    private Material OldMat;

    public float TransparencyValue = 0.5f;

    private bool WallReset = false;
    private bool MatChange = false;
    //private bool WallChange = false;


    //public CapsuleCollider Object;
    public RaycastHit HitData;             //Reference Data from where the Raycast hits.


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Physics.Raycast(GetComponent<Camera>().transform.position, Player.transform.position - GetComponent<Camera>().transform.position, out HitData, 20);
        Debug.DrawRay(GetComponent<Camera>().transform.position, Player.transform.position - GetComponent<Camera>().transform.position);

        if (HitData.transform.gameObject != Wall)
        {
            PrevWall = Wall;
            Wall = null;
            WallReset = true;
            MatChange = true;
            //WallChange = false;
        }

        if (WallReset == true && PrevWall != null)
        {
            PrevWall.GetComponent<MeshRenderer>().material = OldMat;
            WallReset = false;
        }



        if (HitData.collider.tag == "Wall" || HitData.collider.tag == "DestructibleObject" || HitData.collider.tag == "RotationBlocks")
        {
            //if (WallCheck != HitData.transform.gameObject)
            //{
            //    WallCheck = HitData.transform.gameObject;
            //    WallChange = true;
                
            //}
            Wall = HitData.transform.gameObject;
            if (MatChange == true)
            {
                OldMat = Wall.GetComponent<MeshRenderer>().material;
                MatChange = false;
            }

            var WallColors = Wall.GetComponent<MeshRenderer>();
            WallColors.material = TranMat;

            WallColors.material.color = new Color(WallColors.material.color.r, WallColors.material.color.g, WallColors.material.color.b, TransparencyValue);
            //WallChange = true;
        }


    }
}
