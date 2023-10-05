using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHandle : MonoBehaviour
{
    //private Vector3 initialMousePos;
    //private Vector3 initialScale;
    private Transform parentTransform;
    private Vector3 initialSize;
    private float originalDistance;
    private Vector3 initialPosition;
    private Vector3 mouseDelta;
    private Vector3 newSize;
    private float distance;
    //private RectTransform rectTransform;

    //public GameObject overlay_select, overlay_drag,
    public GameObject selectedObject;
    private bool is_dragged;
    public bool dropMeNow, isPlaced;
    Vector3 offset;
    //fieldPosition;

    private void Start()
    {
        parentTransform = transform.parent;
        initialPosition = transform.position;

        is_dragged = false;
        dropMeNow = false;
        isPlaced = false;

        originalDistance = Vector3.Distance(parentTransform.position, transform.position);
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



    }





    private void OnMouseDrag()
    {

        is_dragged = true;
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnMouseUp()
    {
        //overlay_drag.SetActive(false);
        is_dragged = false;

    }

}



