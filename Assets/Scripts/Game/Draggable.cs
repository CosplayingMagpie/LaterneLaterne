using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{

    //public GameObject overlay_select, overlay_drag,
    public GameObject selectedObject;
    private bool is_dragged, is_droppable;
    public bool dropMeNow, isPlaced;
    Vector3 offset;
    //fieldPosition;

    [SerializeField] GameObject colorButton;
    [SerializeField] GameObject outline;
    [SerializeField] GameObject resizeHandle;

    // Start is called before the first frame update
    void Start()
    {
        is_dragged = false;
        is_droppable = false;
        dropMeNow = false;
        isPlaced = false;

        if(colorButton != null)
        {
            colorButton.SetActive(false);
            outline.SetActive(false);
            resizeHandle.SetActive(false);
        }




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

        //if (dropMeNow)
        //{
        //    transform.position = fieldPosition + new Vector3(0, 1, 0);

        //    dropMeNow = false;
        //    isPlaced = true;
        //    GetComponent<Collider2D>().isTrigger = false;

        //}
        //if (Input.GetMouseButtonUp(0) && selectedObject)
        //{
        //    //Debug.Log("brauch ich dich wirklich?");
        //    //selectedObject = null;
        //}
    }

    private void OnMouseOver()
    {
        //overlay_select.SetActive(true);
        if (colorButton != null)
        {
            colorButton.SetActive(true);
            outline.SetActive(true);
            resizeHandle.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        //overlay_select.SetActive(false);
        //overlay_drag.SetActive(false);
        if (colorButton != null)
        {
            colorButton.SetActive(false);
            outline.SetActive(false);
            resizeHandle.SetActive(false);
        }

    }

    private void OnMouseDrag()
    {
        //overlay_drag.SetActive(true);
        is_dragged = true;
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnMouseUp()
    {
        //overlay_drag.SetActive(false);
        is_dragged = false;
        if (is_droppable)
        {
            dropMeNow = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Drop me here");
        if (collision.tag == "Body")
        {
            transform.SetParent(collision.transform);
        }

        //is_droppable = true;
        //fieldPosition = collision.transform.position;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //Debug.Log("Collision detected");
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Out of the area");

        if (collision.tag == "Body")
        {
            transform.SetParent(null);
        }

        is_droppable = false;
        isPlaced = false;
    }
}

