using UnityEngine;

public class TileManager : MonoBehaviour
{
    bool isDragging = false;
    private Vector3 offset;
    public bool canDrop = true;
    public bool isPlaced = false;
    Vector2 startPos;
    public bool hasCounted = false;
    public bool canTakeInput = true;
    private void OnMouseDown()
    {
        if(canTakeInput)
        {
            startPos = transform.position;
            isDragging = true;
            offset = transform.position - MousePosition();
        }
    }
    private void OnMouseDrag()
    {
        if (isDragging && canTakeInput)
        {
            transform.position = MousePosition() + offset;
        }
    }
    private void OnMouseUp()
    {
        if (canTakeInput)
        {
            isDragging = false;
            if (canDrop)
            {
                isPlaced = true;
            }
            else
            {
                transform.position = startPos;
            }
        }
    }
    private void Update()
    {
        CheckChild();
        if(isPlaced)
        {
            isDragging = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    void CheckChild()
    {
        foreach (Transform child in transform)
        {
            TileStick tileStick = child.GetComponent<TileStick>();
            if (tileStick.isinSquare)
            {
                gameObject.SetActive(false);
            }
            if (tileStick != null)
            {
                
                if (!tileStick.isFit) 
                {
                    canDrop = false;
                    break; 
                }
                else
                {
                    canDrop = true;
                }
            }
        }
    }
    Vector3 MousePosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
