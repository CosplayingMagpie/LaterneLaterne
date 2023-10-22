using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]

public class DragObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    private DragManager _manager = null;

    private Vector2 _centerPoint;
    private Vector2 _worldCenterPoint => transform.TransformPoint(_centerPoint);

    public bool isDragged;

    private void Awake()
    {
        _manager = GetComponentInParent<DragManager>();
        _centerPoint = (transform as RectTransform).rect.center;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragged = true;
        if(gameObject.tag == "Handle")
        {
            return;
        }

        else
        {
            _manager.RegisterDraggedObject(this);
        }
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_manager.IsWithinBounds(_worldCenterPoint + eventData.delta))
        {
            transform.Translate(eventData.delta, Space.World);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragged = false;

        if (gameObject.tag == "Handle")
        {
            return;
        }

        else
        {
            _manager.UnregisterDraggedObject(this);
        }
        
    }
}
