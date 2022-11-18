using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    public Vector3 Target;
    public GameObject ColExp;
    public float Speed;

    private AudioSource Explo;

    private void Start()
    {
        Explo = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float Step = Speed * Time.deltaTime;

        if (Target != null)
        {
            if (transform.position == Target)
            {
                Explode();
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, Target, Step);
        }





        //transform.position += transform.forward * Time.deltaTime * 1000f;
    }

    public void SetTarget(Vector3 CurrentTarget)
    {
        Target = CurrentTarget;
    }



    void Explode()
    {
        if (ColExp != null)
        {
            //Explo.Play();
            GameObject Explosion = (GameObject)Instantiate(ColExp, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(Explosion, 1f);
        }
    }



}
