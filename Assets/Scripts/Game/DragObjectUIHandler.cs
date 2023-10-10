using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObjectUIHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject colorChangeButton;
    private GameObject resizeHandle;

    [SerializeField] float UILingerTime;

    // Start is called before the first frame update
    void Start()
    {
        // Get UI Elements for the crafting Object
        colorChangeButton = transform.GetChild(0).gameObject;
        resizeHandle = transform.GetChild(1).gameObject;
        DeactivateUI();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DeactivateUI()
    {
        colorChangeButton.SetActive(false);
        resizeHandle.SetActive(false);
    }

    private void ActivateUI()
    {
        colorChangeButton.SetActive(true);
        resizeHandle.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ActivateUI();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(ShowUIForAWhileLonger());
    }

    private IEnumerator ShowUIForAWhileLonger()
    {
        yield return new WaitForSeconds(UILingerTime);
        DeactivateUI();
    }
}
