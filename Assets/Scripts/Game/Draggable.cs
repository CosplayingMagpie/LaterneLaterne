using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{
    public GameObject selectedObject;
    private bool is_dragged;
    private Vector3 offset;

    //[SerializeField] GameObject colorButton;
    [SerializeField] GameObject outline;
    [SerializeField] GameObject resizeHandle;

    // Start is called before the first frame update
    void Start()
    {
        //if(colorButton != null)
        {
            //colorButton.SetActive(false);
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

             selectedObject = targetObject.transform.gameObject;
             offset = selectedObject.transform.position - mousePosition;
        }
        if (is_dragged && selectedObject != null)
        {

            selectedObject.transform.position = mousePosition + offset;
        }

    }

    private void OnMouseOver()
    {
        //overlay_select.SetActive(true);
        //if (colorButton != null)
        {
            //colorButton.SetActive(true);
            outline.SetActive(true);
            resizeHandle.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
             //colorButton.SetActive(false);
            outline.SetActive(false);
            resizeHandle.SetActive(false);
    }

    private void OnMouseDrag()
    {
        is_dragged = true;
        //GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnMouseUp()
    {
        is_dragged = false;
        selectedObject = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Adds the crafting piece to the lantern as child
        if (collision.tag == "Body")
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Removes the lantern as the parent and set the crafting piece free
        if (collision.tag == "Body")
        {
            transform.SetParent(null);
        }
    }
}

