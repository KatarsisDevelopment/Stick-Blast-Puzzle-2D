using UnityEngine;
public class GameOverManager : MonoBehaviour
{
    GridManager gridManager;
    void Start()
    {
        gridManager = FindAnyObjectByType<GridManager>();
    }
    public void CheckGameOver()
    {
        if (gridManager == null)
        {
            gridManager = FindAnyObjectByType<GridManager>();
        }
        else
        {
            Debug.Log("bulamadý");
        }
        bool allOccupied = true;
        int minLength = Mathf.Min(gridManager.HorStick.GetLength(0), gridManager.HorStick.GetLength(1), gridManager.VerStick.GetLength(0), gridManager.VerStick.GetLength(1));
        for (int i = 0; i < minLength; i++)
        {
            if (!gridManager.HorStick[i, i].isOccopied || !gridManager.VerStick[i, i].isOccopied)
            {
                allOccupied = false;
                break;
            }
        }
        if (allOccupied)
        {
            for (int i = 0; i < gridManager.TileCreator.activeTile.Count; i++)
            {
                string tileName = gridManager.TileCreator.activeTile[i].name;

                if (tileName == "Tile -(Clone)" || tileName == "Tile I(Clone)")
                {
                    Debug.Log("Continue");
                }
                else if (tileName == "Tile RU(Clone)" || tileName == "Tile L(Clone)")
                {
                    Debug.Log("GameOver");
                    gridManager.TileCreator.activeTile[i].GetComponent<TileManager>().canTakeInput = false;
                    gridManager.GOpanel.SetActive(true);

                }
            }
        }
    }
}
