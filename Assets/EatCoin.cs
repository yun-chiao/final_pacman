using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCoin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // 檢查碰到的物體是否是玩家
        if (other.CompareTag("Pacman"))
        {
            // 玩家碰到金幣，觸發消失效果
            Destroy(gameObject);
        }
    }
}
