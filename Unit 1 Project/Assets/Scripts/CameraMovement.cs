using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //code from chatGPT
    public Transform target; // The player's transform
    public float smoothSpeed = 0.125f; // The speed at which the camera follows the player
    public Vector3 offset; // The offset of the camera from the player

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
