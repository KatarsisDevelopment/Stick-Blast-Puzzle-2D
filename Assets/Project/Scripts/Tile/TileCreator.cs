using System.Collections.Generic;
using UnityEngine;

public class TileCreator : MonoBehaviour
{
    public GameObject[] tileObjs;
    public int tileCount;
    public List<GameObject> activeTile = new List<GameObject>();
    void Start()
    {
        CreatTile();
    }
    void Update()
    {
        CheckTileCount();
        if (tileCount == 0)
        {
            CreatTile();
        }
        CheckActiveTiles();
    }
    void CheckActiveTiles()
    {
        foreach (Transform tile in transform)
        {
            TileManager tileManager = tile.GetComponent<TileManager>();
            if (tileManager != null)
            {
                if(tileManager.isPlaced)
                {
                    activeTile.Remove(tileManager.gameObject);
                }
            }
        }
    }
    void CreatTile()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector2 ýnstantPos = new Vector2(transform.position.x + i * 2, -3);
            GameObject ýnstantObj = Instantiate(tileObjs[Random.Range(0,tileObjs.Length)],ýnstantPos,Quaternion.identity);
            ýnstantObj.transform.SetParent(transform);
            tileCount ++;
            activeTile.Add(ýnstantObj);
        }
    }
    void CheckTileCount()
    {
        foreach (Transform child in transform)
        {
            TileManager tileManager = child.GetComponent<TileManager>();
            if (tileManager.isPlaced && !tileManager.hasCounted )
            {
                tileCount -= 1;
                tileManager.hasCounted = true;
            }
        }
    }

}
