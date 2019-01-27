using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargauxAnim : MonoBehaviour
{
    public static MargauxAnim Instance;


    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of MargauxAnim!");
        }
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
