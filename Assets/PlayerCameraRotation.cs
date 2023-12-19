using UnityEngine;

public class PlayerCameraRotation : MonoBehaviour
{
    public float sensitivity = 20f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        // 根據滑鼠移動旋轉攝像機
        transform.Rotate(Vector3.up * mouseX * sensitivity);
    }
}
