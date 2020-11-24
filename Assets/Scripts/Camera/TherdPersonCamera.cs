using UnityEngine;

public class TherdPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 3;
    public Transform target;
    public float distanceToTaget = 50;
    
    public Vector2 pitchMinMax = new Vector2(5, 90);//x min, y max

    float yaw;//horizontalRotation
    float pitch;//verticalRotation

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        Vector3 targetRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = targetRotation;

        transform.position = target.position - transform.forward * distanceToTaget;
    }
}
