using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutlineMaterialHandler : MonoBehaviour
{
    private Material _material;
    private Image _image;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _image.sprite = transform.parent.GetComponent<Image>().sprite;
    }

}
