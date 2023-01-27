using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScreenScript : MonoBehaviour
{
    [SerializeField]
    GameObject selector;

    [SerializeField]
    GameObject[] row1;

    [SerializeField]
    GameObject[] row2;



    const int cols = 3;
    const int rows = 2;

    Vector2 positionIndex;
    GameObject currentSlot;

    bool isMoving = false;
    public GameObject[,] grid = new GameObject[rows, cols];
    // Start is called before the first frame update
    void Start()
    {
        AddRowToGrid(0, row1);
        AddRowToGrid(1, row2);



        positionIndex = new Vector2(1, 1);
        currentSlot = grid[1, 1];
    }


    void AddRowToGrid(int index, GameObject[] row)
    {

        for (int i = 0; i < 3; i++)
        {
            grid[index, i] = row[i];
        }


    }
    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        if (xAxis>0)
        {
            MoveSelector("right");
        }
        else if (xAxis<0)
        {
            MoveSelector("left");
        }
        else if (yAxis>0)
        {
            MoveSelector("up");
        }
        else if (yAxis<0)
        {
            MoveSelector("down");
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            string levelID = currentSlot.GetComponent<LevelSelectitemScript>().levelID;
            SceneManager.LoadScene(levelID);
        }

    }


    void MoveSelector(string direction)
    {
        if(isMoving == false)
        {
            isMoving = true;
            if (direction== "right")
            {
                if (positionIndex.x < cols - 1)
                {
                    positionIndex.x += 1;
                }
            }
           else if (direction == "left")
            {
                if (positionIndex.x > 0)
                {
                    positionIndex.x -= 1;
                }
            }
           else if (direction == "up")
            {
                if (positionIndex.y > 0)
                {
                    positionIndex.y -= 1;
                }
            }
            else if (direction == "down")
            {
                if (positionIndex.y < rows -1)
                {
                    positionIndex.y += 1;
                }
            }
            currentSlot = grid[(int)positionIndex.y, (int)positionIndex.x];
            selector.transform.position = currentSlot.transform.position;
            Invoke("ResetMoving", 0.2f);
        }
    }

    void ResetMoving()

    {
        isMoving = false;
    }
}
