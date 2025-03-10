using Unity.VisualScripting;
using UnityEngine;

public class TileStick : MonoBehaviour
{
    public LayerMask mask;
    public bool isStick = false;
    Vector2 offsetPosition;
    public bool isFit = false;
    public bool isinSquare = false;
    void Update()
    {
        if (!isStick)
        {
            offsetPosition = transform.position;
        }
        else
        {
            offsetPosition = new Vector2(transform.position.x + 0.5f, transform.position.y);
            if (transform.rotation == Quaternion.Euler(0, 0, 90))
            {
                offsetPosition = new Vector2(transform.position.x, transform.position.y + 0.5f);
            }
        }
        HitandFit();
    }
    public void HitandFit()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(offsetPosition, transform.up, 0.1f, mask);
        if (!hit2D)
        {
            isFit = false;
            return;
        }
        if (isStick)
        {
            GridStick gridStick = hit2D.collider.GetComponent<GridStick>();
            if (gridStick)
            {
                isFit = !gridStick.isOccopied && !gridStick.isSquare;

                if (GetComponentInParent<TileManager>().isPlaced && gridStick.isSquare)
                {
                    isinSquare = true;
                }
            }
        }
        else
        {
            isFit = true;
        }
        TileManager tileManager  = GetComponentInParent<TileManager>();
        if(tileManager.isPlaced)
        {
          GridStick gridStick =  hit2D.collider.gameObject.GetComponent<GridStick>();
          if(gridStick != null)
          {
                gridStick.isOccopied = true;
          }
        }
       
    }
}
