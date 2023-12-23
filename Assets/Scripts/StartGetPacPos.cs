using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGetPacPos : MonoBehaviour
{
    public GameObject canvas;
    // Update is called once per frame
    void Update()
    {
        //Todo: /source/7/aed float 1 float (bgm位置 水平角度 縱向角度 距離, 更新速度0.1s)
        //Angle: 開始畫面中小精靈位置和觀眾夾角
        float x = transform.position.x - 800 / 2;
        float z = 800 / 2;
        float Angle = Mathf.Atan(x/z) * Mathf.Rad2Deg;
    }
}
