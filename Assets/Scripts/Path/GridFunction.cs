using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFunction : MonoBehaviour
{
    public int rows = 10;
    public int columns = 10;

    public int scale = 1;
    public GameObject grid;
    public Vector3 L_bottom_loc = new Vector3(0, 0, 0);

    public GameObject[,] grid_arr;
    public int start_X= 0;
    public int start_Y = 0;
    public int end_X = 0;
    public int end_y = 0;
    // Start is called before the first frame update
    void Awake()
    {
        grid_arr = new GameObject[columns, rows];

        if (grid)
        {
            Gen_Grid();
        }
        else
        {
            Debug.Log("missing grid, assign");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Gen_Grid() 
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject inst_obj = Instantiate(grid, new Vector3(L_bottom_loc.x + scale * i,
                                                                    L_bottom_loc.y,
                                                                    L_bottom_loc.z + scale * j), Quaternion.identity);

                inst_obj.transform.SetParent(gameObject.transform);
                inst_obj.GetComponent<GridStats>().x = i;
                inst_obj.GetComponent<GridStats>().y = j;

                grid_arr[i, j] = inst_obj;
            }
        }
    }

    void Setup()
    {
        foreach (GameObject inst_obj in grid_arr)
        {
            inst_obj.GetComponent<GridStats>().found = -1;
        }

        grid_arr[start_X, start_Y].GetComponent<GridStats>().found = 0;
    }

    bool TestDirection(int x, int y, int step, int dir)
    {
        switch (dir)
        {
            case 1:
                if (y + 1 < rows && grid_arr[x, y + 1] && grid_arr[x, y + 1].GetComponent<GridStats>().found == step)
                {
                    return true;
                }
                else
                    return false;

            case 2:
                if (x + 1 < columns && grid_arr[x + 1, y] && grid_arr[x + 1, y].GetComponent<GridStats>().found == step)
                {
                    return true;
                }
                else
                    return false;

            case 3:
                if (y - 1 < -1 && grid_arr[x, y - 1] && grid_arr[x, y - 1].GetComponent<GridStats>().found == step)
                {
                    return true;
                }
                else
                    return false;

            case 4:
                if (x - 1 < -1 && grid_arr[x - 1, y] && grid_arr[x - 1, y].GetComponent<GridStats>().found == step)
                {
                    return true;
                }
                else
                    return false;
        }
        return false;
    }


}
