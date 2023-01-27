using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{

    public float dirY, moveSpeed = 3f;
    bool moveUp = true;

    public float upperY;
   public float lowerY;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y>upperY)
        {
            moveUp = false;
        }
        if (transform.position.y<lowerY)
        {
               moveUp = true;
        }
        if (moveUp)
            transform.position = new Vector2(transform.position.x , transform.position.y + moveSpeed * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x , transform.position.y - moveSpeed * Time.deltaTime);
    }
}
