using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 2;
    public int Health;
    public int InvTimer = 5;
    public float SpeedBoost = 2f;
    private float HurtChange = 0f;

    private GameObject Player;
    private GameObject PlayerController;

    private GameObject[] Death;

    public Movement PlayerMove;

    public MeshRenderer PlayerMesh;

    private bool Hurt = false;
    public bool DeathStateAllowed = false;
    private bool PlayerHurt = false;

    public HealthUI Bar;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerController = GameObject.FindGameObjectWithTag("PlayerController");
        Death = GameObject.FindGameObjectsWithTag("DeathScreen");
        Health = MaxHealth;
        Bar.MAXHealth(MaxHealth);
        Base();
        PlayerMesh = Player.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Health == 0)
        {
            //print("Dead");
        }

        
        if (PlayerHurt == true)
        {
            HurtChange += Time.deltaTime / 1f;
            
            if (HurtChange >= 0.25f)
            {
                //PlayerMesh.enabled = false;
                if (PlayerMesh.enabled == true)
                {
                    PlayerMesh.enabled = false;
                    //print(PlayerMesh.enabled);
                    HurtChange = 0f;
                    
                }
                else if (PlayerMesh.enabled == false)
                {
                    PlayerMesh.enabled = true;
                    //print(PlayerMesh.enabled);
                    HurtChange = 0f;
                    
                }
            }
        }





    }

    public void DamagePlayer(int Hit)
    {
        if (Hurt == false)
        {
            Hurt = true;
            StartCoroutine(Invulnerable());
            Health = Health - Hit;
            Bar.SliderValue(Health);
        }

        if (Health == 0 && DeathStateAllowed == true)
        {
            Dead();
        }

    }

    IEnumerator Invulnerable()
    {
        PlayerHurt = true;
        HurtChange = 0f;
        PlayerController.GetComponent<Movement>().Invulnerable = true;
        yield return new WaitForSeconds(InvTimer);
        Hurt = false;
        PlayerController.GetComponent<Movement>().Invulnerable = false;
        PlayerHurt = false;
        PlayerMesh.enabled = true;
        print("End");
    }

    public void Base()
    {
        foreach (var i in Death)
        {
            i.SetActive(false);
        }
    }

    private void Dead()
    {
        foreach (var i in Death)
        {
            i.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
