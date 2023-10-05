using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeHandler : MonoBehaviour
{

    private Transform parentTransform;
    private Vector3 initialSize;
    private float originalDistance;
    private Vector3 initialPosition;
    private Vector3 mouseDelta;
    private Vector3 newSize;
    private float distance;

    //For getting rotation
    private Vector3 originalDirection;
    private Vector3 newDirection;


    public GameObject selectedObject;
    private bool is_dragged;
    public bool dropMeNow, isPlaced;
    Vector3 offset;
    //fieldPosition;

    private void Start()
    {
        parentTransform = transform.parent;



        is_dragged = false;
        dropMeNow = false;
        isPlaced = false;

        //setting up the sizing variables
        originalDistance = Vector3.Distance(parentTransform.position, transform.position);
        initialSize = parentTransform.localScale;
        initialPosition = transform.position;

        //setting up the rotation Variables
        originalDirection = parentTransform.position - transform.position;
    }




    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            //Wird ausgeführt, wenn angeklickt
            if (targetObject)
            {

                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        if (is_dragged)
        {

            selectedObject.transform.position = mousePosition + offset;
        }



        //Calculates the new size depending on the distance dragged
        distance = Vector3.Distance(parentTransform.position, transform.position);
        float newScale = distance / originalDistance;
        newScale = Mathf.Clamp(newScale, 0.5f, 1.5f);

        //sets the new size
        parentTransform.localScale = new Vector3 (1, 1, 1) * newScale;

        //calculates the new rotation
        newDirection = parentTransform.position - transform.position;
        float angle = Vector3.Angle(originalDirection, newDirection);

        //sets the new rotation depending on y-value
        if (transform.position.y < parentTransform.position.y)
        {
            parentTransform.rotation = Quaternion.Euler(0, 0, angle);
        }

        else
        {
            parentTransform.rotation = Quaternion.Euler(0, 0, -angle);
        }
        

    }





    private void OnMouseDrag()
    {

        is_dragged = true;
        //GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnMouseUp()
    {
        
        is_dragged = false;

        //resets position of handle and parent size, so next resizing will be to new scale
        initialPosition = transform.position;
        initialSize = parentTransform.localScale;

        //resetting up the rotation Variables
        originalDirection = parentTransform.position - transform.position;
    }

}



