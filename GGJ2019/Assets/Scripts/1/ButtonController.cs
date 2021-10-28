using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    //Sprites
    public Sprite defaultPlaySprite;
    public Sprite correspondingPlaySpriteForClick;

    public Sprite defaultCreditsSprite;
    public Sprite correspondingCreditsSpriteForClick;

    //Canvas+GameScene1
    public GameObject Scene1;
    public GameObject CanvaScene;
    public GameObject CanvaMainScreen;
    public GameObject DialogManager;
    public GameObject PanelCredits;
    public GameObject PanelMain;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.name == "Play")
        {
            gameObject.GetComponent<Image>().sprite = correspondingPlaySpriteForClick;
        }

        if (gameObject.name == "Credits")
        {
            gameObject.GetComponent<Image>().sprite = correspondingCreditsSpriteForClick;
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (gameObject.name == "Play")
        {
            gameObject.GetComponent<Image>().sprite = defaultPlaySprite;
        }

        if (gameObject.name == "Credits")
        {
            gameObject.GetComponent<Image>().sprite = defaultCreditsSprite;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Play")
        {
            DialogManager.SetActive(true);
            Scene1.SetActive(true);
            CanvaScene.SetActive(true);
            CanvaMainScreen.SetActive(false);

            SoundsEffects.Instance.MakeDecorSound();
        }

        if (gameObject.name == "Credits")
        {
            PanelCredits.SetActive(true);
            PanelMain.SetActive(false);

            SoundsEffects.Instance.MakeDecorSound();
        }

        if (gameObject.name == "Back")
        {
            PanelMain.SetActive(true);
            PanelCredits.SetActive(false);

            SoundsEffects.Instance.MakeDecorSound();
        }

        if (gameObject.name == "Exit")
        {
            Application.Quit();
        }
    }
}
