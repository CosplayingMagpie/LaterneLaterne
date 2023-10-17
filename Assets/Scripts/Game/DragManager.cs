using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform
        //_defaultLayer = null,
        _dragLayer = null,
        _parentLayer,
        _lanternLayer;

    private Rect _boundingBox;

    private DragObject _currentDraggedObject = null;
    public DragObject CurrentDraggedObject => _currentDraggedObject;

    //Temp
    [SerializeField] GameObject lantern;

    private void Awake()
    {
        SetBoundingBoxRect(_dragLayer);
    }

    public void RegisterDraggedObject(DragObject drag)
    {
        _currentDraggedObject = drag;
        _parentLayer = _currentDraggedObject.transform.parent.GetComponent<RectTransform>();
        Debug.Log(_parentLayer);
        drag.transform.SetParent(_dragLayer);
        
    }

    public void UnregisterDraggedObject(DragObject drag)
    {
        Debug.Log("isOverLatnern " + lantern.GetComponent<LanternTest>().isOverLantern);
        if(lantern.GetComponent<LanternTest>().isOverLantern == true && _currentDraggedObject.tag == "DragObject")
        {
            drag.transform.SetParent(lantern.transform);
        }

        //else if(_currentDraggedObject.tag == "DragObject")
        //{
        //    drag.transform.SetParent(_defaultLayer);
        //}

        else
        {
            drag.transform.SetParent(_parentLayer);
        }


        _currentDraggedObject = null;
    }

    public bool IsWithinBounds(Vector2 position)
    {
        return _boundingBox.Contains(position);
    }

    private void SetBoundingBoxRect(RectTransform rectTransform)
    {
        var corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        var position = corners[0];

        Vector2 size = new Vector2(
            rectTransform.lossyScale.x * rectTransform.rect.size.x,
            rectTransform.lossyScale.y * rectTransform.rect.size.y);

        _boundingBox = new Rect(position, size);
    }
}
