using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;

public class GridManager : MonoBehaviour
{
    public GameObject GridCricle;
    public GameObject GridStick;
    public GameObject Square;
    public int GridSize = 5;
    private GridStick[,] HorStick;
    private GridStick[,] VerStick;
    private SquareObj[,] SquareOb;
    public TileCreator TileCreator;
    public GameObject GOpanel;
    void Start()
    {
        //Desc
        HorStick = new GridStick[GridSize - 1, GridSize ];
        VerStick = new GridStick[GridSize , GridSize - 1];  
        SquareOb = new SquareObj[(int)Mathf.Pow(GridSize - 1 , 2) / (GridSize - 1), (int)Mathf.Pow(GridSize - 1, 2) / (GridSize - 1)];
        //Genereating 
        GenerateGrid();
        GenerateStick();
        GenerateSquare();
        //Camera Control
        Camera.main.transform.position = new Vector3((float)GridSize / 2 - 0.5f, 0,-10);
        Camera.main.orthographicSize = GridSize;
    }
    void Update()
    {
        CheckSquare();
        SqaureDestroy();
        CheckGameOver();
    }
    void GenerateStick()
    {
        //Vertical 
        for (int x = 0; x < GridSize ; x++)
        {
            for (int y = 0; y < GridSize - 1; y++)
            {
                Vector2 ýnstantPos = new Vector2(x , y );
                GameObject GstickObj = Instantiate(GridStick, ýnstantPos, Quaternion.Euler(0,0,90));
                VerStick[x,y] = GstickObj.GetComponent<GridStick>();
                GstickObj.transform.SetParent(transform);
            }
        }
        //Horizontal
        for (int x = 0; x < GridSize - 1; x++)
        {
            for (int y = 0; y < GridSize ; y++)
            {
                Vector2 ýnstantPos = new Vector2(x , y);
                GameObject GstickObj = Instantiate(GridStick, ýnstantPos, Quaternion.Euler(0, 0, 0));
                HorStick[x, y] = GstickObj.GetComponent<GridStick>();
                GstickObj.transform.SetParent(transform);
            }
        }
    }
    void GenerateGrid()
    {
       for(int x = 0; x < GridSize; x++)
       {
            for (int y = 0; y < GridSize; y++)
            {
                Vector2 ýnstantPos = new Vector2(x  , y  );
                GameObject GridObj = Instantiate(GridCricle,ýnstantPos,Quaternion.identity);
                GridObj.transform.SetParent(transform);
            }
       }
    }
    void GenerateSquare()
    {
        for (int x = 0; x < Mathf.Pow(GridSize - 1, 2) / (GridSize - 1); x++)
        {
            for (int y = 0; y < Mathf.Pow(GridSize - 1, 2) / (GridSize - 1); y++)
            {
                Vector2 PosSquare = new Vector2(x + 0.5f, y + 0.5f);
                GameObject SquareObj = Instantiate(Square, PosSquare, Quaternion.identity);
                SquareObj.transform.SetParent(transform);
                SquareObj.gameObject.SetActive(false);
                SquareOb[x,y] = SquareObj.GetComponent<SquareObj>();
            }
        }
    }
    void CheckSquare()
    {
        for (int x = 0; x < GridSize - 1; x++)
        {
            for (int y = 0; y < GridSize - 1; y++)
            {
                if (HorStick[x, y]?.isOccopied == true &&
                    HorStick[x, y + 1]?.isOccopied == true &&
                    VerStick[x, y]?.isOccopied == true &&
                    VerStick[x + 1, y]?.isOccopied == true)
                {
                    SquareOb[x, y].gameObject.SetActive(true);
                    SquareOb[x, y].IsActive = true;
                    //Sticks
                    HorStick[x, y].isSquare = true;
                    HorStick[x, y + 1].isSquare = true;
                    VerStick[x, y].isSquare = true;
                    VerStick[x + 1, y].isSquare = true;
                }
            }
        }
    }
    void SqaureDestroy()
    {
        for (int y = 0; y < GridSize - 1; y++) 
        {
            bool isRowActive = true;
            for (int x = 0; x < GridSize - 1; x++) 
            {
                if (SquareOb[x, y] == null || !SquareOb[x, y].IsActive)
                {
                    isRowActive = false;
                    break; 
                }
            }
            if (isRowActive)
            {
                for (int x = 0; x < GridSize - 1; x++)
                {
                    SquareOb[x, y].gameObject.SetActive(false);
                    SquareOb[x, y].IsActive = false; 
                    HorStick[x, y].isSquare = false;
                    HorStick[x, y + 1].isSquare = false;
                    VerStick[x, y].isSquare = false;
                    VerStick[x + 1, y].isSquare = false;

                    HorStick[x, y].isOccopied = false;
                    HorStick[x, y + 1].isOccopied = false;
                    VerStick[x, y].isOccopied = false;
                    VerStick[x + 1, y].isOccopied = false;
                }
            }
        }
        for (int x = 0; x < GridSize - 1; x++) 
        {
            bool isColumnActive = true;

            for (int y = 0; y < GridSize - 1; y++)
            {
                if (SquareOb[x, y] == null || !SquareOb[x, y].IsActive)
                {
                    isColumnActive = false;
                    break; 
                }
            }
            if (isColumnActive)
            {
                for (int y = 0; y < GridSize - 1; y++)
                {
                    SquareOb[x, y].gameObject.SetActive(false);
                    SquareOb[x, y].IsActive = false; 
                    HorStick[x, y].isSquare = false;
                    HorStick[x, y + 1].isSquare = false;
                    VerStick[x, y].isSquare = false;
                    VerStick[x + 1, y].isSquare = false;

                    HorStick[x, y].isOccopied = false;
                    HorStick[x, y + 1].isOccopied = false;
                    VerStick[x, y].isOccopied = false;
                    VerStick[x + 1, y].isOccopied = false;
                }
            }
        }
    }
    void CheckGameOver()
    {
        bool allOccupied = true;
        int minLength = Mathf.Min(HorStick.GetLength(0), HorStick.GetLength(1), VerStick.GetLength(0), VerStick.GetLength(1));
        for (int i = 0; i < minLength; i++)
        {
            if (!HorStick[i, i].isOccopied || !VerStick[i, i].isOccopied)
            {
                allOccupied = false;
                break;
            }
        }
        if (allOccupied)
        {
            for (int i = 0; i < TileCreator.activeTile.Count; i++)
            {
                string tileName = TileCreator.activeTile[i].name;

                if (tileName == "Tile -(Clone)" || tileName == "Tile I(Clone)")
                {
                    Debug.Log("Continue");
                }
                else if (tileName == "Tile RU(Clone)" || tileName == "Tile L(Clone)")
                {
                    Debug.Log("GameOver");
                    TileCreator.activeTile[i].GetComponent<TileManager>().canTakeInput = false;
                    GOpanel.SetActive(true);

                }
            }
        }
    }
}
