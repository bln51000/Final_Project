using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    new Rigidbody rigidbody;
    //AudioSource audioSource;
    [SerializeField] float playerThrust = 100f;
    //[SerializeField] float rocketRotation = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        //ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Space bar is pushed.");
            rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * playerThrust);
            
            
        }else{
            
        }
    }
/*
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A is pushed.");
            transform.Rotate(Vector3.forward * Time.deltaTime * rocketRotation);
        }
        if(Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D is pushed.");
            transform.Rotate(Vector3.back * Time.deltaTime * rocketRotation);
        }
    }*/
}
