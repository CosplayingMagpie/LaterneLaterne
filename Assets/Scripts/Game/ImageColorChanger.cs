using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class ImageColorChanger : MonoBehaviour
{
    private Material material;

    private int currentIndex;


    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Image>().material;
        Debug.Log("current material is " + material);
    }

    public void NextColor()
    {
        Debug.Log("button pressed");
        currentIndex++;
        //Change color via Material change
        GetComponent<Image>().material = MaterialHandler.Instance.GetCraftPaper(currentIndex);
        Debug.Log("current material is " + material);

    }
}
