using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : MonoBehaviour
{
    public GameObject[] Collectibles;
    private GameObject[] EndScreen;
    private GameObject[] FinalScreen;

    private float Control;

    public bool TaskForEnd = false;
    public bool FinalLevel = false;


    // Start is called before the first frame update
    void Start()
    {
        EndScreen = GameObject.FindGameObjectsWithTag("EndScreen");
        FinalScreen = GameObject.FindGameObjectsWithTag("FinalScreen");
        Base();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (TaskForEnd == true)
        {


            Control = Collectibles.Length;
            foreach (var i in Collectibles)
            {
                if (i == null)
                {
                    Control--;
                }
            }


            if (Control == 0 && FinalLevel == false)
            {
                End();
            }
            else if(Control == 0 && FinalLevel == true)
            {
                Finale();
            }
        }
        else
        {
            if (FinalLevel == false)
            {
                End();
            }
            else
            {
                Finale();
            }
        }

    }


    public void Base()
    {
        foreach (var i in EndScreen)
        {
            i.SetActive(false);
        }
        foreach (var i in FinalScreen)
        {
            i.SetActive(false);
        }
    }

    public void End()
    {
        foreach (var i in EndScreen)
        {
            i.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Finale()
    {
        foreach (var i in FinalScreen)
        {
            i.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
