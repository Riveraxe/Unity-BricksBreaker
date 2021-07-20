using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGrid : MonoBehaviour
{
    public int cols;

    public int rows;

    public GameObject Item;
    public float SizeX;
    public float SizeY;
    //public float padding;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tiles = (GameObject)Instantiate(Item, transform);
                float x = col * SizeX;
                float y = row * -SizeY;
                tiles.transform.position = new Vector2(x, y);
            }
        }

        float GridH = cols * SizeX;
        float GridW = rows * SizeY;
        transform.position = new Vector2(-GridH/2 + SizeX/2, GridW/2 - SizeY/2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
