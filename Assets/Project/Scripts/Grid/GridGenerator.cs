using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    GridManager gridManager;
    private void Start()
    {
        gridManager = FindAnyObjectByType<GridManager>();
        gridManager.HorStick = new GridStick[gridManager.GridSize - 1, gridManager.GridSize];
        gridManager.VerStick = new GridStick[gridManager.GridSize, gridManager.GridSize - 1];
    }
    public void GenerateStick()
    {
        //Vertical 
        for (int x = 0; x < gridManager.GridSize; x++)
        {
            for (int y = 0; y < gridManager.GridSize - 1; y++)
            {
                Vector2 ýnstantPos = new Vector2(x, y);
                GameObject GstickObj = Instantiate(gridManager.GridStick, ýnstantPos, Quaternion.Euler(0, 0, 90));
                gridManager.VerStick[x, y] = GstickObj.GetComponent<GridStick>();
                GstickObj.transform.SetParent(transform);
            }
        }
        //Horizontal
        for (int x = 0; x < gridManager.GridSize - 1; x++)
        {
            for (int y = 0; y < gridManager.GridSize; y++)
            {
                Vector2 ýnstantPos = new Vector2(x, y);
                GameObject GstickObj = Instantiate(gridManager.GridStick, ýnstantPos, Quaternion.Euler(0, 0, 0));
                gridManager.HorStick[x, y] = GstickObj.GetComponent<GridStick>();
                GstickObj.transform.SetParent(transform);
            }
        }
    }
    public void GenerateGrid()
    {
        for (int x = 0; x < gridManager.GridSize; x++)
        {
            for (int y = 0; y < gridManager.GridSize; y++)
            {
                Vector2 ýnstantPos = new Vector2(x, y);
                GameObject GridObj = Instantiate(gridManager.GridCricle, ýnstantPos, Quaternion.identity);
                GridObj.transform.SetParent(transform);
            }
        }
    }
}
