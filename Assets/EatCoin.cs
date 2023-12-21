using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCoin : MonoBehaviour
{
    public OSC osc;
    void OnTriggerEnter(Collider other)
    {
        // 檢查碰到的物體是否是玩家
        if (other.CompareTag("Pacman"))
        {
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
}
