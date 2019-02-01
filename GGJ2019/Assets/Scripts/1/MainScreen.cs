using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainScreen : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    //Sprites
    public Sprite defaultSprite;
    public Sprite correspondingSpriteForClick;

    //Canvas+GameScene1
    public GameObject Scene1;
    public GameObject CanvaScene;
    public GameObject CanvaMainScreen;
    public GameObject DialogManager;

    public void Start()
    {
        Scene1.SetActive(false);
        CanvaScene.SetActive(false);
        CanvaMainScreen.SetActive(true);
        DialogManager.SetActive(false);

        SoundsEffects.Instance.MakeAmbientSound();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = correspondingSpriteForClick;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        gameObject.GetComponent<Image>().sprite = defaultSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameObject.name == "Play")
        {
            DialogManager.SetActive(true);
            Scene1.SetActive(true);
            CanvaScene.SetActive(true);
            CanvaMainScreen.SetActive(false);

            SoundsEffects.Instance.MakeDecorSound();

        }
    }
}
