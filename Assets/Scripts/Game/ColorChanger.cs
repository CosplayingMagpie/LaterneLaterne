using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Use this if you want to change the color via script
    //[SerializeField] Color[] colors;

    //Use this, to change color via Sprite change
    [SerializeField] Sprite[] coloredSprites;

    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void NextColor()
    {
        currentIndex++;
        // Use this, if you want to change the color via script
        //currentIndex %= colors.Length;
        //spriteRenderer.color = colors[currentIndex];

        // Use this, to change color via sprite change
        spriteRenderer.sprite = coloredSprites[currentIndex];
    }
    private void OnMouseUp()
    {
        NextColor();
    }
}
