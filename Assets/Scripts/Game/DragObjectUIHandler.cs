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
    public Material outlineMaterial, wobbleMaterial;

    private Coroutine UICountdown;
    private bool isUILingering;
    private bool isUIVanishing;

    private Tween fade1, fade2, fade3;

    [SerializeField] float UILingerTime;

    // Start is called before the first frame update
    void Start()
    {
        // Get UI Elements for the crafting Object
        colorChangeButton = transform.GetChild(1).gameObject;
        resizeHandle = transform.GetChild(0).gameObject;
        outline = transform.GetChild(2).gameObject;

        // Copy Outline Material
        outlineMaterial = Instantiate(outline.GetComponent<Image>().materialForRendering);
        outline.GetComponent<Image>().material = outlineMaterial;

        // Copy UI Material
        wobbleMaterial = Instantiate(colorChangeButton.GetComponent<Image>().materialForRendering);
        colorChangeButton.GetComponent<Image>().material = wobbleMaterial;

        // Set Start Values
        wobbleMaterial.SetFloat("_Fade", 1);
        colorChangeButton.SetActive(false);

        resizeHandle.GetComponent<Image>().DOFade(0, 0);
        resizeHandle.SetActive(false);

        //outline.GetComponent<Image>().DOFade(0, 1);
        outlineMaterial.SetFloat("_Fade", 1);
        //outline.SetActive(false);
    }

    private void FadeInUI()
    {
        if (isUILingering)
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
        resizeHandle.SetActive(true);
        resizeHandle.GetComponent<Image>().DOFade(1, 0.5f);

        //outline.SetActive(true);
        outlineMaterial.DOFloat(0, "_Fade", 0.5f);
        wobbleMaterial.DOFloat(0, "_Fade", 0.5f);
    }

    private void FadeOutUI()
    {
        isUIVanishing = true;

        fade1 = resizeHandle.GetComponent<Image>().DOFade(0, 0.5f);
        fade2 = outlineMaterial.DOFloat(1, "_Fade", 0.5f);
        fade3 = wobbleMaterial.DOFloat(1, "_Fade", 0.5f).OnComplete(() =>
        {
            colorChangeButton.SetActive(false);
            resizeHandle.SetActive(false);
            //outline.SetActive(false);

            isUIVanishing = false;
        });
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isUILingering == true)
        {
            StopCoroutine(UICountdown);
            isUILingering = false;
        }

        if(isUIVanishing == true)
        {
            fade1.Kill();
            fade2.Kill();
            fade3.Kill();
            isUIVanishing = false;
            //colorChangeButton.SetActive(true);
            //resizeHandle.SetActive(true);
        }

        FadeInUI();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       UICountdown =  StartCoroutine(ShowUIForAWhileLonger());
    }

    private IEnumerator ShowUIForAWhileLonger()
    {
        isUILingering = true;
        yield return new WaitForSeconds(UILingerTime);
        isUILingering = false;
        FadeOutUI();
    }
}
