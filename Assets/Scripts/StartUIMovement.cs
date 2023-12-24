using UnityEngine;

public class StartGhostMovement : MonoBehaviour
{
    public RectTransform canvasRectTransform;
    void Update()
    {
        Vector3 movement = new Vector3(-1f, 0, 0);
        Vector3 pos = transform.position;
        float width = canvasRectTransform.rect.width;
        float scale = canvasRectTransform.localScale.x;
        float moveSpeed = 200f * scale;
        if (pos.x < 0)
        {
            pos.x = width * scale;
            transform.position = pos;
        }
        else
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }
}