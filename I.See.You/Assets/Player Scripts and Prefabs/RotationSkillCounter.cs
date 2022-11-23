using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationSkillCounter : MonoBehaviour
{
    public float RotCounter = 3f;
    public float MaxCounter = 3f;
    public float Recharge = 4f;
    private bool Check = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RotCounter < MaxCounter && Check == true)
        {
            StopCoroutine(RotSkill());
            Check = false;
            //print("Hit");
            RotCounter++;
            
            if (RotCounter < MaxCounter)
            {
                
                StartCoroutine(RotSkill());
            }
        }
    }


    public IEnumerator RotSkill()
    {
        
        yield return new WaitForSeconds(Recharge);
        Check = true;
    }


}
