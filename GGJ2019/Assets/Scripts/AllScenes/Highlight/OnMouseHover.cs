using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnMouseHover : MonoBehaviour
{
    public GameObject objectPointed;
    public GameObject mouse;


    void Start()
    {
        mouse.SetActive(false);
    }

    void OnMouseOver()
    {
        mouse.SetActive(true);
    }

    private void OnMouseExit()
    {
        mouse.SetActive(false);

    }

    void Update()
    {

    }
}
