using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalPlatform : MonoBehaviour

{
    public float speed = 2.0f; // Adjust the speed as needed
    public Vector2 direction = new Vector2(1, 1); // Adjust the direction

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingToEnd = true;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(direction.x, direction.y, 0);
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, step);
            if (Vector3.Distance(transform.position, endPos) < 0.01f)
                movingToEnd = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            if (Vector3.Distance(transform.position, startPos) < 0.01f)
                movingToEnd = true;
        }
    }
}
