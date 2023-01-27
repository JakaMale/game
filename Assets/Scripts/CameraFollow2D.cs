using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    [SerializeField]
    int speedOffset;
    [SerializeField]
    Vector2 posOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = Player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -1;
        transform.position = Vector3.Lerp(startPos, endPos, speedOffset * Time.deltaTime);
    }
}
