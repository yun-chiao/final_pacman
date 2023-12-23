using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
public OSC osc;
public float speed = 2;
public float step_span = 0.5f;
private Rigidbody rb;
private bool isMoving = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY; // 凍結 Y 軸上下移動
        rb.freezeRotation = true;
        StartCoroutine(CheckMovement());
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isMoving = false;
        if(x!=0){
            Vector3 movement = new Vector3(x, 0, 0);
            movement = Camera.main.transform.TransformDirection(movement);
            transform.Translate(movement * speed * Time.deltaTime);
            isMoving = true;
        }
        else if(z!=0){
            Vector3 movement = new Vector3(0, 0, z);
            movement = Camera.main.transform.TransformDirection(movement);
            transform.Translate(movement * speed * Time.deltaTime);
            isMoving = true;
        }
    }
    IEnumerator CheckMovement()
    {
        while (true)
        {
            yield return new WaitForSeconds(step_span);

            if (isMoving)
            {
                OscMessage message;
                // TODO: 每0,5秒如果有在動就傳要腳步聲
                Debug.Log("Player is moving");
                message = new OscMessage();
                message.address = "/trigger/6";
                message.values.Add(1);
                osc.Send(message);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            //Todo: 到遊戲結束畫面SS
            SceneManager.LoadScene("GameOver");
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Eat coin");
        }
    }

}
