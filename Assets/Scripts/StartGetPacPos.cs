using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGetPacPos : MonoBehaviour
{
    public GameObject canvas;
    // Update is called once per frame
    void Update()
    {
        //Todo: /source/7/aed float 1 float (bgm��m �������� �a�V���� �Z��, ��s�t��0.1s)
        //Angle: �}�l�e�����p���F��m�M�[������
        float x = transform.position.x - 800 / 2;
        float z = 800 / 2;
        float Angle = Mathf.Atan(x/z) * Mathf.Rad2Deg;
    }
}
