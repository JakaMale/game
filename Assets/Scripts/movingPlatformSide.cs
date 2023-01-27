using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformSide : MonoBehaviour
{

   public float dirX, moveSpeed = 3f;
    bool moveRight = true;

    public float upperX;
    public float lowerX;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > upperX)
        {
            moveRight = false;
        }
        if (transform.position.x < lowerX)
        {
            moveRight = true;
        }
        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y );
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y );
    }
}
