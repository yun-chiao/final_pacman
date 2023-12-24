using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendInfo : MonoBehaviour
{
    public OSC osc;
    public int FrameRate = 30;    // 設定資料更新頻率
    public float CoinSoundInterval = 1f;
    public Transform ghost; 
    public Transform[] coins;
    private int CoinSoundFrame;
    private int CoinSoundFrame_counter=0;
    void Start()
    {
        Time.fixedDeltaTime = 1/(float)FrameRate;
        CoinSoundFrame = (int)(CoinSoundInterval*FrameRate);
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
            message = new OscMessage();
            message.address = "/source/5/aed";
            message.values.Add(ghost_pacman_angle);
            message.values.Add(1);
            message.values.Add(distance);
            osc.Send(message);
        }
        //find nearest coin
        int coin_nearest_id=-1;
        float min_dist=9999999f;
        for (int i=0;i<coins.Length;i++)
        {
            Transform coin=coins[i];
            if (coin != null)
            {
                float distance = Vector3.Distance(transform.position, coin.position);
                if(distance<min_dist)
                {
                    min_dist=distance;
                    coin_nearest_id=i;
                }
            }
        }
        if (coin_nearest_id!=-1)
        {
            Transform coin=coins[coin_nearest_id];
            // 獲取金幣相對於玩家的位置
            Vector3 relativePosition = coin.position - transform.position;
            float distance = Vector3.Distance(transform.position, coin.position);

            // 計算金幣相對於正面的角度差
            float coin_pacman_angle = Vector3.SignedAngle(Camera.main.transform.forward, relativePosition, Vector3.up);

            // TODO: 這邊傳送各個金幣與玩家的水平角度差以及直線距離 縱向應該就是0
            // /source/1/aed 金幣1
            message = new OscMessage();
            message.address = string.Format("/source/{0}/aed",coin_nearest_id+1);
            message.values.Add(coin_pacman_angle);
            message.values.Add(1);
            message.values.Add(distance);
            osc.Send(message);
            // Debug.Log("Coin_pacman angle, distance: " + coin_pacman_angle + ", "+distance);
        }
        if(CoinSoundFrame_counter%CoinSoundFrame==0)
        {
            CoinSoundFrame_counter=0;
            if(coin_nearest_id!=-1)
            {
                message = new OscMessage();
                message.address = string.Format("/trigger/{0}",coin_nearest_id+1);
                message.values.Add(1);
                osc.Send(message);
            } 
        }

        // for (int i=0;i<coins.Length;i++)
        // {
        //     Transform coin=coins[i];
        //     if (coin != null)
        //     {
        //         // 獲取金幣相對於玩家的位置
        //         Vector3 relativePosition = coin.position - transform.position;
        //         float distance = Vector3.Distance(transform.position, coin.position);

        //         // 計算金幣相對於正面的角度差
        //         float coin_pacman_angle = Vector3.SignedAngle(Camera.main.transform.forward, relativePosition, Vector3.up);

        //         // TODO: 這邊傳送各個金幣與玩家的水平角度差以及直線距離 縱向應該就是0
        //         // /source/1/aed 金幣1
        //         message = new OscMessage();
        //         message.address = string.Format("/source/{0}/aed",i+1);
        //         message.values.Add(coin_pacman_angle);
        //         message.values.Add(1);
        //         message.values.Add(distance);
        //         osc.Send(message);
        //         // Debug.Log("Coin_pacman angle, distance: " + coin_pacman_angle + ", "+distance);
        //     }
        //     if (coin == null){
        //         // TODO: 如果這個金幣已經被吃掉了的話 看要傳什麼
        //         // 我覺得是直接不傳
        //     }
        // }
        // //時間到了 傳金幣聲
        // if(CoinSoundFrame_counter%CoinSoundFrame==0)
        // {
        //     CoinSoundFrame_counter=0;
        //     for (int i=0;i<coins.Length;i++)
        //     {
        //         Transform coin=coins[i];
        //         if (coin != null)
        //         {
        //             message = new OscMessage();
        //             message.address = string.Format("/trigger/{0}",i+1);
        //             message.values.Add(1);
        //             osc.Send(message);
        //         }
        //     }
        // }
        // relativePosition = ghost.position - transform.position;
        // distance = Vector3.Distance(transform.position, ghost.position);
        // ghost_pacman_angle = Vector3.SignedAngle(Camera.main.transform.forward, relativePosition, Vector3.up);
        CoinSoundFrame_counter+=1;
    }
    
}
