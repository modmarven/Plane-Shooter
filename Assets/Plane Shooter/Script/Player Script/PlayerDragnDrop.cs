using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDragnDrop : MonoBehaviour
{
    public Dragger lastDragged => draggerLast;

    private bool isDragActive = false;

    private Vector2 screenPosition;

    private Vector3 worldPosition;

    private Dragger draggerLast;

    private void Update()
    {
        if (isDragActive && (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            DropObject();
            return; 
        }
       if (Input.touchCount > 0)
        {
            screenPosition = Input.GetTouch(0).position;
        }

        else
        {
            return;
        }

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (isDragActive)
        {
            DragObject();
        }

        else
        {
            RaycastHit2D raycast2D = Physics2D.Raycast(worldPosition, Vector2.zero);
            if (raycast2D.collider != null)
            {
                Dragger dragger = raycast2D.transform.gameObject.GetComponent<Dragger>();
                if (dragger != null)
                {
                    draggerLast = dragger;
                    InitialDrager();
                }
            }
        }
    }

    private void InitialDrager()
    {
        UpdateDragStatus(true);
    }

    private void DragObject()
    {
        draggerLast.transform.position = new Vector2(worldPosition.x, worldPosition.y);
    }

    private void DropObject()
    {
        UpdateDragStatus(false);
    }

    private void UpdateDragStatus(bool IsDragging)
    {
        isDragActive = lastDragged.IsDragging = IsDragging;
        gameObject.layer = IsDragging ? Layer.Dragging : Layer.Default;
    }
}
