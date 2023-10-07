using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LanternTest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isOverLantern { get; private set; }


    public void OnPointerEnter(PointerEventData eventData)
    {

        isOverLantern = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        isOverLantern = false;
    }


}
