using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGetPacPos : MonoBehaviour
{
    public OSC osc;
    public GameObject canvas;
    // Update is called once per frame
    public float FrameRate = 30f;    // 設定資料更新頻率
    void Start()
    {
        Time.fixedDeltaTime = 1/FrameRate;
    }
    void FixedUpdate()
    {
        OscMessage message;
        //Todo: /source/7/aed float 1 float (bgm位置 水平角度 縱向角度 距離, 更新速度0.1s)
        //Angle: 開始畫面中小精靈位置和觀眾夾角
        float x = transform.position.x - 800 / 2;
        float z = 800 / 2;
        float Angle = Mathf.Atan2(z,x) * Mathf.Rad2Deg -90;
        float distance = Mathf.Sqrt(z*z+x*x);
        message = new OscMessage();
        message.address = "/source/7/aed";
        message.values.Add(Angle);
        message.values.Add(1);
        message.values.Add(distance);
        osc.Send(message);
    }
}
