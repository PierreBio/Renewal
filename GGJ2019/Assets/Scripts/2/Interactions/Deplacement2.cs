using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement2 : MonoBehaviour
{
    public GameObject mainCharacter;

    void OnMouseDown()
    {
        if (gameObject.name == "awards2Collider")
        {
            Dialog2.Instance.AwardsEvent();
        }

        if (gameObject.name == "Oncle")
        {
            Dialog2.Instance.UncleEvent();
        }
    }
    
}
