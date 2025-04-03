using UnityEngine;

public class SquareManager : MonoBehaviour
{
    GridManager gridManager;
    void Start()
    {
        gridManager = FindAnyObjectByType<GridManager>();
    }
    void Update()
    {
        
    }
    public  void GenerateSquare()
    {
        for (int x = 0; x < Mathf.Pow(gridManager.GridSize - 1, 2) / (gridManager.GridSize - 1); x++)
        {
            for (int y = 0; y < Mathf.Pow(gridManager.GridSize - 1, 2) / (gridManager.GridSize - 1); y++)
            {
                Vector2 PosSquare = new Vector2(x + 0.5f, y + 0.5f);
                GameObject SquareObj = Instantiate(gridManager.Square, PosSquare, Quaternion.identity);
                SquareObj.transform.SetParent(transform);
                SquareObj.gameObject.SetActive(false);
                gridManager.SquareOb[x, y] = SquareObj.GetComponent<SquareObj>();
            }
        }
    }
    public  void CheckSquare()
    {
        for (int x = 0; x < gridManager.GridSize - 1; x++)
        {
            for (int y = 0; y < gridManager.GridSize - 1; y++)
            {
                if (gridManager.HorStick[x, y]?.isOccopied == true &&
                    gridManager.HorStick[x, y + 1]?.isOccopied == true &&
                    gridManager.VerStick[x, y]?.isOccopied == true &&
                    gridManager.VerStick[x + 1, y]?.isOccopied == true)
                {
                    gridManager.SquareOb[x, y].gameObject.SetActive(true);
                    gridManager.SquareOb[x, y].IsActive = true;
                    //Sticks
                    gridManager.HorStick[x, y].isSquare = true;
                    gridManager.HorStick[x, y + 1].isSquare = true;
                    gridManager.VerStick[x, y].isSquare = true;
                    gridManager.VerStick[x + 1, y].isSquare = true;
                    //Score 
                }
            }
        }
    }
    public  void SqaureDestroy()
    {
        for (int y = 0; y < gridManager.GridSize - 1; y++)
        {
            bool isRowActive = true;
            for (int x = 0; x < gridManager.GridSize - 1; x++)
            {
                if (gridManager.SquareOb[x, y] == null || !gridManager.SquareOb[x, y].IsActive)
                {
                    isRowActive = false;
                    break;
                }
            }
            if (isRowActive)
            {
                for (int x = 0; x < gridManager.GridSize - 1; x++)
                {
                    gridManager.SquareOb[x, y].gameObject.SetActive(false);
                    gridManager.SquareOb[x, y].IsActive = false;
                    gridManager.HorStick[x, y].isSquare = false;
                    gridManager.HorStick[x, y + 1].isSquare = false;
                    gridManager.VerStick[x, y].isSquare = false;
                    gridManager.VerStick[x + 1, y].isSquare = false;

                    gridManager.HorStick[x, y].isOccopied = false;
                    gridManager.HorStick[x, y + 1].isOccopied = false;
                    gridManager.VerStick[x, y].isOccopied = false;
                    gridManager.VerStick[x + 1, y].isOccopied = false;
                }
            }
        }
        for (int x = 0; x < gridManager.GridSize - 1; x++)
        {
            bool isColumnActive = true;

            for (int y = 0; y < gridManager.GridSize - 1; y++)
            {
                if (gridManager.SquareOb[x, y] == null || !gridManager.SquareOb[x, y].IsActive)
                {
                    isColumnActive = false;
                    break;
                }
            }
            if (isColumnActive)
            {
                for (int y = 0; y < gridManager.GridSize - 1; y++)
                {
                    gridManager.SquareOb[x, y].gameObject.SetActive(false);
                    gridManager.SquareOb[x, y].IsActive = false;
                    gridManager.HorStick[x, y].isSquare = false;
                    gridManager.HorStick[x, y + 1].isSquare = false;
                    gridManager.VerStick[x, y].isSquare = false;
                    gridManager.VerStick[x + 1, y].isSquare = false;

                    gridManager.HorStick[x, y].isOccopied = false;
                    gridManager.HorStick[x, y + 1].isOccopied = false;
                    gridManager.VerStick[x, y].isOccopied = false;
                    gridManager.VerStick[x + 1, y].isOccopied = false;
                }
            }
        }
    }
}
