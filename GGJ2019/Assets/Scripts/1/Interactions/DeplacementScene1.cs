using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementScene1 : MonoBehaviour
{
    public GameObject mainCharacter;

    void OnMouseDown()
    {
        if (gameObject.name == "presentCollider")
        {
            Dialog1.Instance.PresentEvent();
        }
        if (gameObject.name == "doorCollider")
        {
            Dialog1.Instance.doorEvent();
        }
        if (gameObject.name == "sofaCollider")
        {
            Dialog1.Instance.sofaEvent();
        }
    }
}
