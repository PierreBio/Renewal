using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject MainCharacter;

    public GameObject Object1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

     public bool interaction1 ()
    {
        if(Mathf.Abs(MainCharacter.transform.position.x - Object1.transform.position.x)< 0.5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void appearInteractionButton()
    {

    }
}
