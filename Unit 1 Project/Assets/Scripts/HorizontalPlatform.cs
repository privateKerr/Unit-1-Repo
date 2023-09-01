using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    public float speed = 2.0f; // Adjust the speed as needed
    public float distance = 4.0f; // Adjust the distance the platform travels

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingToEnd = true;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.right * distance;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, step);
            if (transform.position == endPos)
                movingToEnd = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            if (transform.position == startPos)
                movingToEnd = true;
        }
    }
}
