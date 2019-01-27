using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog7 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject BackgroundText;

    bool isDisplayingText = false;

    public static Dialog7 Instance;


    // Start is called before the first frame update
    void Start()
    {
        FirstText();
        BackgroundText.SetActive(true);
        continueButton.SetActive(false);
        if (isDisplayingText == false)
        {
            StartCoroutine(Type());
            isDisplayingText = true;
        }
    }

    IEnumerator Type()
    {
        continueButton.SetActive(false);
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            SoundsEffects.Instance.MakeTypingSound();
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NexSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            if (isDisplayingText == true)
            {
                StartCoroutine(Type());
            }
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            isDisplayingText = false;
            BackgroundText.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (textDisplay.text == sentences[index])
        {
            BackgroundText.SetActive(true);
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }

    }

    //Events which can happened
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of Dialog2!");
        }
        Instance = this;
    }

    void FirstText()
    {
        this.sentences = new string[] {
         /*"Margaux : Uncle ! I saw you at the tv, that was amazing ! *(Majuscules ?)* right uppercut , left hook and K.O. Did you beat all of them?",         
          "Margaux :Have you ever lost ? Are your opponents scared about you before the match ?",
        "Eric : Slowly, Slowly, young girl. The match that you saw wasn’t the most impressive, but the one I’m preparing is !",
        "M : You have another fight ?" ,
        "E : The finale comes. A critical stage that require a lot of physical preparation as well as mental preparation.",
        " M : *Attentive*",
        " E : Unfortunately an old injury has resurfaced in my last fight.",
        "  M : Is it a serious injury? You shouldn’t go then…",
        "NO ! That’s when we see true champions.Those who know to surpass themselves.",
         "Those who are capable of tap to their limits and even beyond !",
        " A : Margaux is right.This fight is too dangerous in your state Eric.",
        " E : And that’s when we rewrite history young girl. We can’t become champions " +
        "without taking any risks and without surpass ourselves.",*/
         " M : I will watching you on TV uncle !"};
    }

    public void AwardsEvent()
    {
        if (isDisplayingText == false)
        {
            this.sentences = new string[] {
        "M : A puppy ?!",
        "A : Happy Birthday Margaux !",
        " J : I present to you the new member of our family ! What’s his name ?" ,
         "M : Max",
         " A : Welcome home Max !"
        };

            index = 0;
            StartCoroutine(Type());
            isDisplayingText = true;
        }
    }

}
