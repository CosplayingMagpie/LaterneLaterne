using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]

public class DragHandle : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    //private DragManager _manager = null;

    private Vector2 _centerPoint;
    private Vector2 _worldCenterPoint => transform.TransformPoint(_centerPoint);

    private Rect boundingBox;
    private RectTransform parentLayer;

    public bool isDragged;

    private void Awake()
    {
        //_manager = GetComponentInParent<DragManager>();
        //_centerPoint = (transform as RectTransform).rect.center;
        parentLayer = transform.parent.GetComponent<RectTransform>();
        SetBoundingBoxRect(parentLayer);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        isDragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Get Parent object bounds

        if (IsWithinBounds(_worldCenterPoint + eventData.delta))
        {
            transform.Translate(eventData.delta, Space.World);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        isDragged = false;
    }

    private bool IsWithinBounds(Vector2 position)
    {
        return boundingBox.Contains(position);
    }

    private void SetBoundingBoxRect(RectTransform rectTransform)
    {
        var corners = new Vector3[4];
        Debug.Log("corners are " + corners[0] + corners[1] + corners[2] + corners[3]);
        rectTransform.GetWorldCorners(corners);
        var position = corners[0];

        Vector2 size = new Vector2(
            rectTransform.lossyScale.x * rectTransform.rect.size.x,
            rectTransform.lossyScale.y * rectTransform.rect.size.y);

        boundingBox = new Rect(position, size);

        //transform.GetComponentInParent<Renderer>().bounds;
    }
}
