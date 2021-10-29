using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement8 : MonoBehaviour
{
    public GameObject mainCharacter;

    void OnMouseDown()
    {
        if (gameObject.name == "DOGGO")
        {
            Dialog8.Instance.dogEvent();
        }
        if (gameObject.name == "coat")
        {
            Dialog8.Instance.jacketEvent();
        }
    }
}
