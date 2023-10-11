using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class DragObjectUIHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject colorChangeButton;
    private GameObject resizeHandle;
    private GameObject outline;
    private Material outlineMaterial;

    private Coroutine UICountdown;
    private bool isUILingering;
    private bool isUIVanishing;

    private Tween fade1, fade2, fade3;

    [SerializeField] float UILingerTime;

    // Start is called before the first frame update
    void Start()
    {
        // Get UI Elements for the crafting Object
        colorChangeButton = transform.GetChild(0).gameObject;
        resizeHandle = transform.GetChild(1).gameObject;
        outline = transform.GetChild(2).gameObject;
        outlineMaterial = outline.GetComponent<Image>().material;
        Debug.Log(outlineMaterial);

        colorChangeButton.GetComponent<Image>().DOFade(0, 1);
        colorChangeButton.SetActive(false);

        resizeHandle.GetComponent<Image>().DOFade(0, 1);
        resizeHandle.SetActive(false);

        //outline.GetComponent<Image>().DOFade(0, 1);
        outlineMaterial.SetFloat("_Fade", 1);


    }


    private void DeactivateUI()
    {
        isUIVanishing = true;
        fade1 = resizeHandle.GetComponent<Image>().DOFade(0, 0.5f);
        fade3 = outlineMaterial.DOFloat(1, "_Fade", 0.5f);
        fade2 =  colorChangeButton.GetComponent<Image>().DOFade(0, 0.5f).OnComplete(() =>
        {
            colorChangeButton.SetActive(false);
            resizeHandle.SetActive(false);
            //outline.SetActive(false);
            isUIVanishing = false;

        });

    }

    private void ActivateUI()
    {
        if(isUILingering)
        {
            StopCoroutine(UICountdown);
            isUILingering = false;
        }

        if (isUIVanishing)
        {
            DOTween.Kill(fade1);
            DOTween.Kill(fade2);
            isUIVanishing = false;
        }
        colorChangeButton.SetActive(true);
        colorChangeButton.GetComponent<Image>().DOFade(1, 0.5f);
        resizeHandle.SetActive(true);
        resizeHandle.GetComponent<Image>().DOFade(1, 0.5f);

        outlineMaterial.DOFloat(0, "_Fade", 0.5f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ActivateUI();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       UICountdown =  StartCoroutine(ShowUIForAWhileLonger());
    }

    private IEnumerator ShowUIForAWhileLonger()
    {
        isUILingering = true;
        yield return new WaitForSeconds(UILingerTime);
        DeactivateUI();
    }
}
