using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arowdown : MonoBehaviour
{

    private float _speed;
    private float _endPosY;

    public void StartFloating(float speed, float endPosy)
    {
        _speed = speed;
        _endPosY = endPosy;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * (Time.deltaTime * _speed));

        if (transform.position.y < _endPosY)
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
