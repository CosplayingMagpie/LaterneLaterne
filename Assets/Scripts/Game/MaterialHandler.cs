using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHandler : MonoBehaviour
{
    [SerializeField] Texture[] craftPapers;

    public static MaterialHandler Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Texture GetCraftPaper(int index)
    {
        index = index % craftPapers.Length;
        return craftPapers[index];
    }
}
