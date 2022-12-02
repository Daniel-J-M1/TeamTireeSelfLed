using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallConnect : MonoBehaviour
{
    public GameObject[] Walls;

    public List<Material> BaseMat;

    private GameObject Camera;
    private bool ConnectChange = false;
    private Material ConMat;

    private int Index = 0;


    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        ConMat = GetComponent<MeshRenderer>().material;

        foreach (var I in Walls)
        {
            BaseMat.Add(I.GetComponent<MeshRenderer>().material);
            Index++;
            
        }

    }

    void FixedUpdate()
    {
        Index = 0;
        if (Camera.GetComponent<CameraTransparency>().Wall == this.gameObject)
        {
            ConnectChange = false;
            foreach (var I in Walls)
            {
                I.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
            }
        }
        else
        {
            ConnectChange = true;
        }

        if (ConnectChange == true)
        {
            foreach (var I in Walls)
            {
                if(I != Camera.GetComponent<CameraTransparency>().Wall)
                {
                    I.GetComponent<MeshRenderer>().material = BaseMat[Index];
                    Index++;
                }
            }
        }


    }
}
