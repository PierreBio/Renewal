using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour
{
    //Canvas+GameScene1
    public GameObject Scene1;
    public GameObject CanvaScene;
    public GameObject CanvaMainScreen;
    public GameObject DialogManager;

    public void Awake()
    {
        Scene1.SetActive(false);
        CanvaScene.SetActive(false);
        CanvaMainScreen.SetActive(true);
        DialogManager.SetActive(false);

        SoundsEffects.Instance.MakeAmbientSound();
    }
}
