using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendInfo : MonoBehaviour
{
    public OSC osc;
    public float customFixedDeltaTime = 0.2f;    // 設定多久拿到資料一次
    public Transform ghost; 
    public Transform[] coins;

    void Start()
    {
        Time.fixedDeltaTime = customFixedDeltaTime;
    }

    void FixedUpdate()
    {
        OscMessage message;
        if (ghost != null)
        {
            // 獲取鬼和玩家的相對位置
            Vector3 relativePosition = ghost.position - transform.position;
            float distance = Vector3.Distance(transform.position, ghost.position);
            float ghost_pacman_angle = Vector3.SignedAngle(Camera.main.transform.forward, relativePosition, Vector3.up);
            // TODO: 這邊傳送鬼與玩家的水平角度差以及直線距離 縱向應該就是0
            // Debug.Log("Ghost_pacman angle, distance: " + ghost_pacman_angle + ", "+distance);
        }

        foreach (Transform coin in coins)
        {
            if (coin != null)
            {
                // 獲取金幣相對於玩家的位置
                Vector3 relativePosition = coin.position - transform.position;
                float distance = Vector3.Distance(transform.position, coin.position);

                // 計算金幣相對於正面的角度差
                float coin_pacman_angle = Vector3.SignedAngle(Camera.main.transform.forward, relativePosition, Vector3.up);

                // TODO: 這邊傳送各個金幣與玩家的水平角度差以及直線距離 縱向應該就是0
                // /source/1/aed 金幣1
                message = new OscMessage();
                message.address = "/source/1/aed";
                message.values.Add(coin_pacman_angle);
                message.values.Add(1);
                message.values.Add(distance);
                osc.Send(message);
                // Debug.Log("Coin_pacman angle, distance: " + coin_pacman_angle + ", "+distance);
            }
            if (coin == null){
                // TODO: 如果這個金幣已經被吃掉了的話 看要傳什麼
            }
        }
    }

}
