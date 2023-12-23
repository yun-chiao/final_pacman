using UnityEngine;

public class EndGhostMovement : MonoBehaviour
{
    float moveSpeed = 20f;
    int movecount = 0;
    int moveDir = 1;
    void Update()
    {
        Vector3 movement = new Vector3(0f, 1f, 0f);
        Vector3 pos = transform.position;
        transform.Translate(movement* moveDir * moveSpeed * Time.deltaTime);
        movecount++;
        if(movecount > 200)
        {
            moveDir *= -1;
            movecount = 0;
        }
    }
}