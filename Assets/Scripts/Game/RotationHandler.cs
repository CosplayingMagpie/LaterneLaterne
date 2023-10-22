using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private bool isDragged;

    private Transform parentTransform;

    private Vector3 newDirection, originalDirection;

    // Start is called before the first frame update
    void Start()
    {
        parentTransform = transform.parent;

        //setting up the rotation Variables
        originalDirection = parentTransform.position - transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        isDragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.Translate(eventData.delta, Space.World);


        //calculates the new rotation
        newDirection = parentTransform.position - transform.position;
        float angle = Vector3.Angle(originalDirection, newDirection);

        //sets the new rotation depending on y-value
        if (transform.position.y < parentTransform.position.y)
        {
            parentTransform.rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        else
        {
            parentTransform.rotation = Quaternion.Euler(0, 0, -angle);
            transform.rotation = Quaternion.Euler(0, 0, -angle);
        }

        Debug.Log("we rotate");
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        isDragged = false;

        //setting up the rotation Variables
        originalDirection = parentTransform.position - transform.position;
    }
}
