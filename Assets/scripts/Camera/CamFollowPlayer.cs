using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5.0f;

    private void LateUpdate()
    {
        // this creates variable for where we must go as the camera (follow player)
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        // setting the  current camera position to equal to the 'Target' position
        // LERP allows us to smoothly transition between current position to the desiredPosition
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
