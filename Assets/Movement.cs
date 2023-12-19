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
        movement = Camera.main.transform.TransformDirection(movement);
        transform.Translate(movement * speed * Time.deltaTime);
    }
    else if(z!=0){
        Vector3 movement = new Vector3(0, 0, z);
        movement = Camera.main.transform.TransformDirection(movement);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
      void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            // 遊戲結束的相應處理，例如顯示遊戲結束畫面或重置遊戲
            Debug.Log("Game Over");
        }
    }
}

