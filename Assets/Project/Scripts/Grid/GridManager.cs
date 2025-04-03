using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;

public class GridManager : MonoBehaviour
{
    public GameObject GridCricle;
    public GameObject GridStick;
    public GameObject Square;
    public int GridSize = 5;
    public GridStick[,] HorStick;
    public GridStick[,] VerStick;
    public SquareObj[,] SquareOb;
    public TileCreator TileCreator;
    public ScoreAnimController ScoreAnimController;
    public GameObject GOpanel;
    SquareManager squareManager;
    GridGenerator gridGenerator;
    GameOverManager gameOverManager;
    void Start()
    {
        GridSize = MenuController.CountGird;
        //Descr
        HorStick = new GridStick[GridSize - 1, GridSize];
        VerStick = new GridStick[GridSize, GridSize - 1];
        SquareOb = new SquareObj[(int)Mathf.Pow(GridSize - 1, 2) / (GridSize - 1), (int)Mathf.Pow(GridSize - 1, 2) / (GridSize - 1)];
        //Find
        gridGenerator = FindAnyObjectByType<GridGenerator>();
        squareManager = FindAnyObjectByType<SquareManager>();
        gameOverManager = FindAnyObjectByType<GameOverManager>();
        //Genereating 
        gridGenerator?.GenerateGrid();
        gridGenerator?.GenerateStick();
        squareManager?.GenerateSquare();
        //Camera Control
        Camera.main.transform.position = new Vector3((float)GridSize / 2 - 0.5f, 0,-10);
        Camera.main.orthographicSize = GridSize;
    }
    void Update()
    {
        if (HorStick == null || VerStick == null || HorStick[0, 0] == null)
        {
            return;
        }
        squareManager?.CheckSquare();
        squareManager?.SqaureDestroy();
        gameOverManager?.CheckGameOver();
    }
}
