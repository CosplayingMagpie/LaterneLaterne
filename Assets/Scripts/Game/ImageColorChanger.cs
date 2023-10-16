using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class ImageColorChanger : MonoBehaviour
{
    private Material _material;

    private int currentIndex;


    // Start is called before the first frame update
    void Start()
    {
        _material = Instantiate(GetComponent<Image>().material);
        GetComponent<Image>().material = _material;

    }

    public void NextColor()
    {

        currentIndex++;
        //Change color via Material change
        _material.SetTexture("_PaperSprite", MaterialHandler.Instance.GetCraftPaper(currentIndex));
        

    }
}
