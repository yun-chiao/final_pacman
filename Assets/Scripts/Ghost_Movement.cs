using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ghost_Movement : MonoBehaviour
{
    public Transform pacman;
    public float moveDistance = 0.5f;  // 移動距離
    public float moveInterval = 0.5f;  // 移動間隔

    void Start()
    {
        // 啟動移動協程
        StartCoroutine(RandomMovement());
    }

    void Update()
    {
        // 總是使物體的正面朝向相機
        transform.forward = Camera.main.transform.forward;
    }

    IEnumerator RandomMovement()
    {
        while (true)
        {
            Vector3 relativePosition = pacman.position - transform.position;
            Vector3 targetPosition = transform.position;
            float x = relativePosition.x;
            float z = relativePosition.z;
            if (Math.Abs(x) > Math.Abs(z))
            {
                if (x > 0)
                {
                    targetPosition += Vector3.right * moveDistance;
                }
                else
                {
                    targetPosition += Vector3.left * moveDistance;
                }
            }
            else
            {
                if (z > 0)
                {
                    targetPosition += Vector3.forward * moveDistance;
                }
                else
                {
                    targetPosition += Vector3.back * moveDistance;
                }
            }

            // 移動至目標位置
            yield return MoveTo(targetPosition);

            // 等待移動間隔
            yield return new WaitForSeconds(moveInterval);
        }
    }

    IEnumerator MoveTo(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        // 移動時間
        float moveTime = 0.5f;

        while (elapsedTime < moveTime)
        {
            // 只更新 x 和 z 座標，保持 y 座標不變
            Vector3 newPosition = new Vector3(
                Mathf.Lerp(startPosition.x, targetPosition.x, elapsedTime / moveTime),
                startPosition.y,
                Mathf.Lerp(startPosition.z, targetPosition.z, elapsedTime / moveTime)
            );

            transform.position = newPosition;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 確保物體到達目標位置
        transform.position = targetPosition;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pacman"))
        {
            Debug.Log("Game Over");
        }
    }

}