using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

public float speed = 2;
private Rigidbody rb;

void Start()
{
    rb = GetComponent<Rigidbody>();
    rb.constraints = RigidbodyConstraints.FreezePositionY; // 凍結 Y 軸上下移動
    rb.freezeRotation = true;
}
void Update()
{
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");
    if(x!=0){
        Vector3 movement = new Vector3(x, 0, 0);
        movement = Camera.main.transform.TransformDirection(movement);
        transform.Translate(movement * speed * Time.deltaTime);
    }
    else if(z!=0){
        Vector3 movement = new Vector3(0, 0, z);
        movement = Camera.main.transform.TransformDirection(movement);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pacman"))
        {
            Debug.Log("Game Over");
        }
    }

}

