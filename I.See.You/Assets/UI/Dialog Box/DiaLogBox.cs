using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiaLogBox : MonoBehaviour
{
    public GameObject X;
    public GameObject Text;
    private GameObject Player;

    public bool ExitState = false;

    [TextArea (15, 20)]
    public string DialogueText;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PlayerController");
        X = Player.GetComponent<Movement>().X;
        Text = Player.GetComponent<Movement>().Text;
        X.SetActive(false);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            if (ExitState == false)
            {
                Text.GetComponent<TextMeshProUGUI>().text = DialogueText;
                Time.timeScale = 0f;
                X.SetActive(true);
                Destroy(gameObject);
            }
            else
            {
                Text.GetComponent<TextMeshProUGUI>().text = DialogueText;
                X.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
                X.SetActive(false);
        }
    }
}
