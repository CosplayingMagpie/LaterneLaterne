using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHandler : MonoBehaviour
{
    [SerializeField] Material[] craftPapers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Material GetCraftPaper(int index)
    {
        return craftPapers[index];
    }
}
