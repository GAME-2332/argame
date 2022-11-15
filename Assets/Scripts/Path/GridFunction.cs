using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFunction : MonoBehaviour
{
    public bool findDist = false;
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

    public List<GameObject> path = new List<GameObject>();
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
        if (findDist)
        {
            SetDistance();
            SetPath();
            findDist = false;
        }
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

    void SetDistance()
    {
        Setup();
        int x = start_X;
        int y = start_Y;
        int[] test_arr = new int[rows * columns];

        for (int step = 1; step < rows * columns; step++)
        {
            foreach (GameObject inst_obj in grid_arr)
            {
                if (inst_obj && inst_obj.GetComponent<GridStats>().found == step - 1)
                {
                    TestFourDir(inst_obj.GetComponent<GridStats>().x, inst_obj.GetComponent<GridStats>().y, step);
                }
            }
        }
    }

    void SetPath()
    {
        int step;
        int x = end_X;
        int y = end_y;
        List<GameObject> templist = new List<GameObject>();

        path.Clear();

        if (grid_arr[end_X, end_y] && grid_arr[end_X, end_y].GetComponent<GridStats>().found > 0)
        {
            path.Add(grid_arr[x, y]);
            step = grid_arr[x, y].GetComponent<GridStats>().found - 1;
        }
        else 
        {
            Debug.Log("cant reach my destiny");
            return;
        }

        for (int i = step; step > -1; step--)
        {
            if (TestDirection(x, y, step, 1))
            {
                templist.Add(grid_arr[x, y + 1]);
            }
            if (TestDirection(x, y, step, 2))
            {
                templist.Add(grid_arr[x + 1, y]);
            }
            if (TestDirection(x, y, step, 3))
            {
                templist.Add(grid_arr[x, y - 1]);
            }
            if (TestDirection(x, y, step, 4))
            {
                templist.Add(grid_arr[x - 1, y]);
            }
            /*GameObject tempObj = FindClosest(grid_arr[end_X, end_y].transform, templist);
            path.Add(tempObj);
            x = tempObj.GetComponent<GridStats>().x;
            y = tempObj.GetComponent<GridStats>().y;
            templist.Clear();*/
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

    void TestFourDir(int x, int y, int step)
    {
        if (TestDirection(x, y, -1, 1))
        {
            SetFound(x, y + 1, step);
        }
        if (TestDirection(x, y, -1, 2))
        {
            SetFound(x + 1, y, step);
        }
        if (TestDirection(x, y, -1, 3))
        {
            SetFound(x, y - 1, step);
        }
        if (TestDirection(x, y, -1, 4))
        {
            SetFound(x - 1, y, step);
        }
    }

    void SetFound(int x, int y, int step)
    {
        if (grid_arr[x, y])
        {
            grid_arr[x, y].GetComponent<GridStats>().found = step;
        }
    }
}
