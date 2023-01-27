using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arowGeneratorScript : MonoBehaviour
{

    [SerializeField]
    GameObject[] arow;

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    GameObject endPoint;

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        
        Invoke("AttemptSpawn", spawnInterval);

    }

    void SpawnArow(Vector3 startPos)
    {
        int randomIndex = UnityEngine.Random.Range(0, arow.Length);
        GameObject arows = Instantiate(arow[randomIndex]);

        
        arows.transform.position = new Vector3(startPos.x, startPos.y, startPos.z);



        float speed = -5f;
        arows.GetComponent<arowScript>().StartFloating(speed, endPoint.transform.position.x);
    }
    void AttemptSpawn()
    {
        SpawnArow(startPos);
        Invoke("AttemptSpawn", spawnInterval);
    }
    

}
