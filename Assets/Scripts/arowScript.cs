using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arowScript : MonoBehaviour
{
    private float _speed;
    private float _endPosX;

    public void StartFloating(float speed, float endPosx)
    {
        _speed = speed;
        _endPosX = endPosx;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * _speed));

        if (transform.position.x < _endPosX)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}