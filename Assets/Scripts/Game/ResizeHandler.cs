using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeHandler : MonoBehaviour
{
    //private Vector3 initialMousePos;
    //private Vector3 initialScale;
    private Transform parentTransform;
    private Vector2 initialSize;
    private Vector3 initialPosition;
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
        initialSize = parentTransform.localScale;
        initialPosition = transform.position;

        is_dragged = false;
        dropMeNow = false;
        isPlaced = false;
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

        distance = Vector3.Distance(initialPosition, transform.position);
        Vector2 newSize = initialSize * (1 + distance );
        parentTransform.localScale = newSize;

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
        initialPosition = transform.position;
        initialSize = parentTransform.localScale;
    }

}



