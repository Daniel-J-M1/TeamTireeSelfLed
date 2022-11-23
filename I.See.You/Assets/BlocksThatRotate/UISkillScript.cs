using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillScript : MonoBehaviour
{
    private GameObject Player;
    //private UnityEngine.UI.Text RotCounter;

    public Slider Bar;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //RotCounter = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Bar.value = Player.GetComponent<RotationSkillCounter>().RotCounter;
        //print(Player.GetComponent<RotationSkillCounter>().RotCounter);
        //GetComponent<Text>().text = Player.GetComponent<RotationSkillCounter>().RotCounter.ToString();
        //print(Player.GetComponent<RotationSkillCounter>().RotCounter);
    }
}
