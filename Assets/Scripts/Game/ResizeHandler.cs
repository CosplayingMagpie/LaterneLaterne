using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResizeHandler : MonoBehaviour,  IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private DragManager _manager = null;

    private Vector2 _centerPoint;
    private Vector2 _worldCenterPoint => transform.TransformPoint(_centerPoint);

    private Transform parentTransform;
    private RectTransform parentRect;

    private Vector3 initialSize;
    private float originalDistance;
    private Vector3 initialPosition;
    private float distance;

    //For getting rotation
    private Vector3 originalDirection;
    private Vector3 newDirection;

   // public bool canMove;

    private Rect _boundingBox;



    private Rect boundingBox;
    private RectTransform parentLayer;

    public bool isDragged;

    private void Awake()
    {
        
        //_centerPoint = (transform as RectTransform).rect.center;
        parentLayer = transform.parent.GetComponent<RectTransform>();
        //SetBoundingBoxRect(parentLayer);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        isDragged = true;
        //resets position of handle and parent size, so next resizing will be to new scale
        initialPosition = transform.position;
        initialSize = parentTransform.localScale;

        //resetting up the rotation Variables
        originalDirection = parentTransform.position - transform.position;
    }


    private void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragged)
        {
            transform.Translate(eventData.delta, Space.World);

            //Calculates the new size depending on the distance dragged
            distance = Vector3.Distance(parentTransform.position, transform.position);
            float newScale = distance / originalDistance;

            if (newScale <= 0.5f || newScale >= 1.5f)
            {
                newScale = Mathf.Clamp(newScale, 0.5f, 1.5f);
                //canMove = false;

            }

            //sets the new size
            parentTransform.localScale = new Vector3(1, 1, 1) * newScale;

            //calculates the new rotation
            newDirection = parentTransform.position - transform.position;
            float angle = Vector3.Angle(originalDirection, newDirection);

            //sets the new rotation depending on y-value
            if (transform.position.y < parentTransform.position.y)
            {
                parentTransform.rotation = Quaternion.Euler(0, 0, angle);
                //transform.rotation = Quaternion.Euler(0, 0, angle);
            }

            else
            {
                parentTransform.rotation = Quaternion.Euler(0, 0, -angle);
                //transform.rotation = Quaternion.Euler(0, 0, -angle);
            }

            //originalDirection = parentTransform.position - transform.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        isDragged = false;
        //resets position of handle and parent size, so next resizing will be to new scale
        initialPosition = transform.position;
        initialSize = parentTransform.localScale;

        //resetting up the rotation Variables
        originalDirection = parentTransform.position - transform.position;
    }

    private void Start()
    {
        //canMove = true;
        parentTransform = transform.parent;
        parentRect = parentTransform.GetComponent<RectTransform>();

        //setting up the sizing variables
        originalDistance = Vector3.Distance(parentTransform.position, transform.position);
        initialSize = parentTransform.localScale;
        initialPosition = transform.position;

        //setting up the rotation Variables
        originalDirection = parentTransform.position - transform.position;

        //SetBoundingBoxRect(parentRect);
    }






    private void OnMouseUp()
    {

    }

    //private void Awake()
    //{
    //    //_manager = GetComponentInParent<DragManager>();
    //    _centerPoint = (transform as RectTransform).rect.center;
    //}

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    //_manager.RegisterDraggedObject(this);
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    if (IsWithinBounds(_worldCenterPoint + eventData.delta))
    //    {
    //        transform.Translate(eventData.delta, Space.World);

    //        //Calculates the new size depending on the distance dragged
    //        distance = Vector3.Distance(parentTransform.position, transform.position);
    //        float newScale = distance / originalDistance;


    //        newScale = Mathf.Clamp(newScale, 0.5f, 1.5f);




    //        //sets the new size
    //        parentTransform.localScale = new Vector3(1, 1, 1) * newScale;

    //        //calculates the new rotation
    //        newDirection = parentTransform.position - transform.position;
    //        float angle = Vector3.Angle(originalDirection, newDirection);

    //        //sets the new rotation depending on y-value
    //        if (transform.position.y < parentTransform.position.y)
    //        {
    //            parentTransform.rotation = Quaternion.Euler(0, 0, angle);
    //            transform.rotation = Quaternion.Euler(0, 0, angle);
    //        }

    //        else
    //        {
    //            parentTransform.rotation = Quaternion.Euler(0, 0, -angle);
    //            transform.rotation = Quaternion.Euler(0, 0, -angle);
    //        }
    //        SetBoundingBoxRect(parentRect);
    //    }


        
    }

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    //resets position of handle and parent size, so next resizing will be to new scale
    //    initialPosition = transform.position;
    //    initialSize = parentTransform.localScale;

    //    //resetting up the rotation Variables
    //    originalDirection = parentTransform.position - transform.position;

    //    SetBoundingBoxRect(parentRect);
    //}


    //private void SetBoundingBoxRect(RectTransform rectTransform)
    //{
    //    var corners = new Vector3[4];
    //    rectTransform.(corners);
    //    var position = corners[0];

    //    Vector2 size = new Vector2(
    //        rectTransform.lossyScale.x * rectTransform.rect.size.x,
    //        rectTransform.lossyScale.y * rectTransform.rect.size.y);

    //    _boundingBox = new Rect(position, size);
    //}


//}



