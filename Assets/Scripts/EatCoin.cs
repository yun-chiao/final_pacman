using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCoin : MonoBehaviour
{
    public OSC osc;
    /*
    void OnCollisionEnter(Collider other)
    {
        // 檢查碰到的物體是否是玩家
        if (other.CompareTag("Pacman"))
        {
            Debug.Log("Get coin!");
            // 玩家碰到金幣，觸發消失效果
            Destroy(gameObject);
            // TODO: 這邊傳送金幣被吃掉的音效
            OscMessage message;
            message = new OscMessage();
            message.address = "/trigger/8";
            message.values.Add(1);
            osc.Send(message);
        }
    }
    */
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pacman"))
        {
            Destroy(gameObject);
            OscMessage message;
            message = new OscMessage();
            message.address = "/trigger/8";
            message.values.Add(1);
            osc.Send(message);
        }
    }
}