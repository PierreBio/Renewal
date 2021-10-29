using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement5 : MonoBehaviour
{
    public GameObject mainCharacter;

    void OnMouseDown()
    {
        if (gameObject.name == "Jerome")
        {
            Dialog5.Instance.JeromeEvent();
        }
        if (gameObject.name == "Policier")
        {
            Dialog5.Instance.PoliceEvent();
        }
    }
}
