using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highlight1 : MonoBehaviour
{
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