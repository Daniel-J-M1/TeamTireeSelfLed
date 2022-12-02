using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEye : MonoBehaviour
{
    private GameObject[] MenuPoints;

    private int Index;
    private int Control;
    private Vector3 LookPoint;
    private float LookSpeed;

    private bool Change = true;

    // Start is called before the first frame update
    void Start()
    {
        MenuPoints = GameObject.FindGameObjectsWithTag("MenuLookPoints");
        Control = MenuPoints.Length;
        LookSpeed = Random.Range(1, 10) * Time.deltaTime;
        Change = true;
        Debug.Log(Index);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Change == true)
        {
            //print(Index);
            Index = Random.Range(0, (MenuPoints.Length - 1));
            if (Index != Control)
            {
                Control = Index;
                LookPoint = MenuPoints[Index].transform.position - transform.position;
                LookSpeed = Random.Range(1, 10) * Time.deltaTime;
                Change = false;
                StartCoroutine(TimeForChange());
                print(Index);
            }
        }

        Vector3 AimedDirection = Vector3.RotateTowards(transform.forward, LookPoint, LookSpeed, 0.0f);
        transform.rotation = Quaternion.LookRotation(AimedDirection);



        
    }

    IEnumerator TimeForChange()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 3));
        Change = true;
    }



}
