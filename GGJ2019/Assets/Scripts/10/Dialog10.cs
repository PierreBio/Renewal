using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog10 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject BackgroundText;

    bool isDisplayingText = false;

    public static Dialog10 Instance;


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
        "Eric : Hi Max! How are you! Do you always have you strength?",
        "Margot : Yes Eric of course! I’m better than always!",
        "Eric : Well! Your ill was a just a detail as I see! ",
        "Margot : Thanks to Max! He helped me feel better!" ,
        "Max : Yes I help her!",
        "Eric : Oh you’re kind Max!.......",
        "Eric : WHAAAAAAT?MAX!? YOU’RE SPEAKING!",
        "Margot: Yes, he isspeaking dog!",
        "Eric : It’s impossible! It’s a trap!",
        "Margot: No I assure you! ",
        "Max : Hello Eric! I know you don’t believe me, but it’s true!",
        "Eric : Waaaaah!",
        "Max : I’m from the future. A world of possibilities is before us.",
        "Eric : Oh my god, you’re real!",
        "Eric : And what about you parents Margot? They know about him?",
        "Aurélie and Jérôme together : Of course we know. Since we discovered his secret, we are reassured.",
        "Eric : Ok, and why are you so calm and happy",
        "Margot : Max came from the future, so he knows something very interesting….",
        "Aurélie and Jérôme : We won the lotery! We are billionaires!!",
        "Eric : You are the best family!What will you do with this money?,",
        "Margot : Max helped us to win, so we decided to give him a half part…",
        "Margot : And we have….",
        "Aurélie and Jérôme : 2 500 000 000 dollars! We have decided to go to Bora Bora for the rest of our life!",
        "Max : I will buy a huge amount of food! (Glurps)",
        "Eric : And you, Margot?",
        "Margot : Oh me?",
        "Margot : I’m not interested at all with their plan.",
        "Margot : I want to be a videogame developer."
        };
    }

}
