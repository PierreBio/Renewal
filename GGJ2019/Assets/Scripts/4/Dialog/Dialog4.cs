using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Dialog4 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject BackgroundText;

    bool isDisplayingText = false;

    public static Dialog4 Instance;


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
            SceneManager.LoadScene("Credits");

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
        "Eric : Margot, I present to you Joshua, he’s in the finale with me.",
         "Margot : Hi Joshua, I’m Margot.",
        "Joshua : Hi! Margot, Eric told me a lot already about his wonderful niece.",
        "Eric & Jérôme : Welcome home Joshua!" ,
        "Eric : Do you want a coffee before starting?",
        "Joshua : Why not, thank you!",
        "Margot: Why are you doing the finale here uncle?",
        "Eric : Because the best fighter can decide the emplacement of their finale!",
        "Margot : That’s cool!",
         "Joshua : So when do we start Eric?!",
        "Eric : Now, Joshua! I hope you came prepared.",
        "Joshua : Who do you think you’re talking to!",
        "Jérôme : Ok, I will give the countdown.",
         "Jérôme: Rock, paper, scissors…",
         "Jérôme : One point for Joshua, zero for Eric.",
         "Jérôme : Rock, paper, scissors…",
         "Jérôme : One point for Eric, one for Joshua",
         "Jérôme : Rock, paper, scissors…",
         "Jérôme : Two points for Joshua, two for Eric",
         "Joshua : You’re stronger than before, it’s a very nice fight.",
         "Eric : Thanks, you’re not bad yourself.",
         "Jérôme : Ok, last round!",
         "Jérôme : Rock, paper, scissors…",
         "Jérôme : And Eric is the winner of the great finale!!",
         "Eric : Yes! It was a true fight, as expected from last year’s champion!",
         "Eric : Yes! It was a true fight, as expected from last year’s champion!",
         "Joshua : Thanks, you deserve the first place, it was an amazing fight.",
         "Margot : …Guys? The fight was not supposed to be boxing ?",
         "Eric : Ahah no, the fighter that you saw in your tv the other day was just somebody who looks like me, a doppelganger you could say.",
         "Margot : So, you never fight with anyone?",
         "Eric : I fight but in another category and I’m the winner! Are you proud of your uncle?",
         "Margot : Of course… yes…!"

        };
    }

}
