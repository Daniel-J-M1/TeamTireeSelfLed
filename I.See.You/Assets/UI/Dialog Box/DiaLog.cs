using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DiaLog : MonoBehaviour
{
    public GameObject X;
    
    public void Exit()
    {
        Time.timeScale = 1f;
        X.SetActive(false);
    }
}
