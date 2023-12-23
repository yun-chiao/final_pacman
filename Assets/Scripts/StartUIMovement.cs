using UnityEngine;

public class StartGhostMovement : MonoBehaviour
{
    public float moveSpeed = 60f;

    void Update()
    {
        Vector3 movement = new Vector3(-1f, 0, 0);
        Vector3 pos = transform.position;
        if(pos.x < 100)
        {
            pos.x = 800;
            transform.position = pos;
        }
        else
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }
}