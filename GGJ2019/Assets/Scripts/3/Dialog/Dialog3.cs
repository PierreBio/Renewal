using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog3 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject BackgroundText;

    bool isDisplayingText = false;

    public static Dialog3 Instance;


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
         "Margot : Mom, come, come uncle is about to fight",
         "Aurélie : I’m finishing this and I’m coming!",
         "Eric : Ok but be quick.!",
         "Commentator : The atmosphere is heavy even here." ,
         "Commentator : Yeah, they are equals, even prognosis can’t decide who is gonna win tonight.",
         "Commentator : Ok, Joshua starts with a feint. Eric moves quickly and stays on his supports",
         "Commentator : He makes a move, tries an uppercut and oooh!!",
         "Commentator : Too slow, he was too slow! Can he get up after this punch you think?",
         "Commentator : Oh no that was a punch from Joshua and he took it right to the head.",
         "Commentator : The medical team is entering the ring, is it that bad?",
         "Margot : Mom! Uncle is not getting up.",
         "Aurélie : What ? *Come in front of the TV* Don’t look at this, come.",
         "Commentator : We are waiting for more information.",
         "Commentator : He’s taken away on a stretcher, we hope that he’ll be fine.",
         "Aurélie : Ok, stop, you can go play now.",
         "Margot  But mom, I want to know if he’s alright.",
         "Commentator : Ok, we have just learned sad news, Mister Eric died tonight."+
         "Commentator : Apparently he had a pretty serious injury before coming and didn’t tell anyone."+
         "Commentator : It was a head injury. He already told us in an interview that he wanted to die doing his passion, " +
         "Commentator : but it was too early for us. The competition will end now with this tragic event, we offer our condolences to his family.",
         "Margot and Aurélie : ...",
         "Margot : it’s not true right?",
         "Aurélie: …Eric…",
         "Margot : Why are you crying? It’s not true, they’re lying, they’re just joking, right?",
         "Aurélie : I’m sorry Margot, you shouldn’t have watched this, you should never have watched this.",
         "Margot :  …Mom…"};
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
