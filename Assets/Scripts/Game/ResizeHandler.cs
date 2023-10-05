using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeHandler : MonoBehaviour
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
        initialSize = parentTransform.localScale;
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



        //mouseDelta = initialPosition - transform.position;

        //newSize = initialSize + mouseDelta;
        //newSize.x = Mathf.Clamp(newSize.x, 0.5f, 1.5f);
        ////Vector3 newSize = initialSize * (1 + distance );
        //parentTransform.localScale = new Vector3 (newSize.x, newSize.x, newSize.x);

        distance = Vector3.Distance(parentTransform.position, transform.position);
        float newScale = distance / originalDistance;
        parentTransform.localScale = new Vector3 (1, 1, 1) * newScale;

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



