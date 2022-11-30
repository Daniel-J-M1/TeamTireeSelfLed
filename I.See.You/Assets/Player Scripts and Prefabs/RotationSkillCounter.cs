using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationSkillCounter : MonoBehaviour
{
    public float RotCounter = 3f;
    public float MaxCounter = 3f;
    public float Recharge = 4f;
    private bool Check = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RotCounter < MaxCounter && Check == true)
        {
            StartCoroutine(RotSkill());
        }

        
        //print("Hit");
        
    }


    public IEnumerator RotSkill()
    {
        Check = false;
        print("Start");
        yield return new WaitForSeconds(Recharge);
        Check = true;
        print("Stop");
        RotCounter++;
    }


}
