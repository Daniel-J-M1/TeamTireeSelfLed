using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCounter : MonoBehaviour
{
    private GameObject[] Keys;
    private int KeysLeft;



    // Start is called before the first frame update
    void Start()
    {
        Keys = GameObject.FindGameObjectsWithTag("SecurityKey");
        KeysLeft = Keys.Length;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = KeysLeft.ToString();
    }




    public void CounterDown()
    {
        KeysLeft--;
    }
}
