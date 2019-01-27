using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject BackgroundText;

    bool isDisplayingText = false;

    public static Dialog2 Instance;


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
        "Margot : Uncle! I saw you on tv, you were amazing! Right uppercut, left hook and K.O. Did you beat all of them? Have you ever lost? Are your opponents scared of you before the match?",
        "Eric : Easy, easy, young lady. The match that you saw wasn’t the most impressive, but the one I’m preparing for will be!",
        "Margot : You have another fight?",
        "Eric : The finale is coming. A critical stage that requires a lot of physical preparation as well as mental preparation. Unfortunately an old injury reared its ugly head during my last fight.",
        "Margot : Is it a serious injury? You shouldn’t go then…",
        "Eric :  NO! That’s when we see true champions.",
        "Those who know how to surpass themselves.",
         "Those who are capable of overcoming their limits and even beyond!",
         "You must never let anything drag you down.",
        "Aurélie : Margot is right.This fight is too dangerous in your state Eric.",
        "Eric : And that’s when we make history young lady. We can’t become champion without taking any risks and without surpassing ourselves.",
        "Margot : I will watch you on TV uncle!"};
    }

    public void AwardsEvent()
    {
        if (isDisplayingText == false)
        {
            this.sentences = new string[] {
        "M : A puppy ?!",
        "A : Happy Birthday Margot !",
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
