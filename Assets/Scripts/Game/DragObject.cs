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

    private void Awake()
    {
        _manager = GetComponentInParent<DragManager>();
        //Checks, whether I can call a function on the manager
        _manager.TestCall();
        _centerPoint = (transform as RectTransform).rect.center;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start drag");
        _manager.RegisterDraggedObject(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("keep on dragging");
        transform.Translate(eventData.delta);
        //if (_manager.IsWithinBounds(_worldCenterPoint + eventData.delta))
        //{

        //}
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Stop the drag");
        _manager.UnregisterDraggedObject(this);
    }
}
