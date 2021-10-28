using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Dialog5 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject BackgroundText;

    bool isDisplayingText = false;

    public static Dialog5 Instance;

    bool eventJerome = false;
    bool eventPolicier = false;


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

            if (eventJerome == true)
            {
                SceneManager.LoadScene("6");
            }
            if (eventPolicier == true)
            {
                SceneManager.LoadScene("7");
            }
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
    "Police :  Please, have a seat.",
    "Aurélie & Jérôme : …",
    "Police :  I came to talk to you about the progress of our investigation.",
    "Aurélie : Did you find the murderer of our daughter?",
    "Police : We made some progress but unfortunately all of our leads were dead ends.",
    "Jérôme  : So what happened? What’s the progress?",
    "Aurélie : There is nothing, no progress at all.",
    "Jérôme  : What do you mean by that? Let this inspector finish, there is surely something, an element you found.",
    "Aurélie : Let him finish? Why? To hear that the investigation is abandoned?",
    "Jérôme  :  He said that they have leads, so they can’t give up so soon. Right, sir?",
    "Police : I’m sorry, really. We decided to stop the investigation because of a lack of elements.",
    "Jérôme  : Stop it? Now? "
};
    }

    public void PoliceEvent()
    {
        if (isDisplayingText == false)
        {
            this.sentences = new string[] {
         "Aurélie:  It’s not because you decided to stop the investigation " +
         "that we’ll stop searching. We refuse to let this man, this woman or whoever" +
         " they are live peacefully without any consequences for their actions. " +
         "This assassin who dared to commit this crime will not go unpunished, I assure you!",
          "Jérôme: Our daughter have the right to rest in peace.",
    "Police : I understand how you feel and I apologize for the turn that the investigation " +
    "took.However I advise you to reconsider your decision.This tragic event…",
    "Jérôme : This tragic event? You’re talking about the death of our Margot and " +
    "there is no way for you to understand what we feel right now.You would not ask us " +
    "to forget this event if that was the case. To mourn we have to know who her murderer " +
    "is and put them behind bars.",
    "Aurélie : We know you were just in charge of announcing this to us. " +
    "Now you can go inspector, we will carry on by ourselves. Good bye."

        };
            eventPolicier = true;
            index = 0;
            StartCoroutine(Type());
            isDisplayingText = true;
        }
    }

    public void JeromeEvent()
    {
        if (isDisplayingText == false)
        {
            this.sentences = new string[] {
        "Aurélie : If you can’t find any evidence, then we can’t do anything about it.",
         "Jérôme: Running out of leads is one thing, giving up is another.How can you make this decision?" +
         " Have you already forgotten what our daughter went through?",
        "Aurélie: How could I forget something like that!We have the right to blame, we have the right to cry, to be angry." +
        " However we are not police officer, in a situation like this one we are forced to accept it.",
        "Police: I advise you to get help from relatives, or outsiders.A departure at such a young age should never happened.",
        "Jérôme: I apologize for being carried away for a moment there, inspector.Such a decision… I..have some difficulty accepting it.",
        "Aurélie : Thank you for keeping us informed inspector and if in the future the investigation were to resume, please, come back to tell us.",
        "Police: Of course. Now, Sir, Madam, if you will excuse me."

        };
            eventJerome = true;
            index = 0;
            StartCoroutine(Type());
            isDisplayingText = true;
        }
    }

}
