using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    //Use this, to change color via Sprite change
    //[SerializeField] Sprite[] coloredSprites;

    private int currentIndex;

    // For testing
    [SerializeField] GameObject paperPrototype;

    // Start is called before the first frame update
    void Start()
    {
        // zum Testen rausgenommen
        //if(transform.parent != null)
        //{
        //    Transform parent = transform.parent;
        //    spriteRenderer = parent.GetComponent<SpriteRenderer>();
        //}


        //Zum Testen reingenommen
        //else
        //{
            spriteRenderer = paperPrototype.GetComponent<SpriteRenderer>();
        //}

    }

    public void NextColor()
    {
        currentIndex++;
        // Use this, if you want to change the color via script
        //currentIndex %= colors.Length;
        //spriteRenderer.color = colors[currentIndex];

        // Use this, to change color via sprite change
        //currentIndex = currentIndex % coloredSprites.Length;
        //spriteRenderer.sprite = coloredSprites[currentIndex];

        //Change color via Material change
        spriteRenderer.material = MaterialHandler.Instance.GetCraftPaper(currentIndex);
        
    }

    private void OnMouseDown()
    {
        NextColor();
    }

    private void OnMouseEnter()
    {
        Debug.Log("Hovered over the color changing button");
    }

}
