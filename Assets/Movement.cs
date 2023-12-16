using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

public float speed = 2;
void Update()
{
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");
    if(x!=0){
        Vector3 movement = new Vector3(x, 0, 0);
        transform.Translate(movement * speed * Time.deltaTime);
    }
    else if(z!=0){
        Vector3 movement = new Vector3(0, 0, z);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
}

