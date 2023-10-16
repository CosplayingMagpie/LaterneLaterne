using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeHandler : MonoBehaviour
{

    private Transform parentTransform;
    private Vector3 initialSize;
    private float originalDistance;
    private Vector3 initialPosition;
    private float distance;

    //For getting rotation
    private Vector3 originalDirection;
    private Vector3 newDirection;



    private void Start()
    {
        parentTransform = transform.parent;

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
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        else
        {
            parentTransform.rotation = Quaternion.Euler(0, 0, -angle);
            transform.rotation = Quaternion.Euler(0, 0, -angle);
        }
        

    }



    private void OnMouseUp()
    {
        //resets position of handle and parent size, so next resizing will be to new scale
        initialPosition = transform.position;
        initialSize = parentTransform.localScale;

        //resetting up the rotation Variables
        originalDirection = parentTransform.position - transform.position;
    }

}



