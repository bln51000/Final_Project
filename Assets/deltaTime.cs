using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deltaTime : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("This is content within the update function");
        //transform.Translate(xValue, yValue, zValue);

        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);
        //transform.Translate(5, 10, 15);
        
    }
}
