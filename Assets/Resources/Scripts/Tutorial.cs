using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;


public class Tutorial : MonoBehaviour
{
    public bool TutorialDone = false;
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] TextMeshProUGUI NextButtonText;
    [SerializeField] GameObject CanavasTutorial;
    private string Part1 = "Welcome!";
    private string Part2 = "In this tutorial, you will learn how to solve a Vector Maze.";
    private string Part3 = "Don't worry, it's not as hard as it sounds!";
    private string Part4 = "The main goal of the game is to get rid of all the vectors in the maze.";
    private string Part5 = "Just click on them";
    private string Part6 = "But...";
    private string Part7 = "Be careful!   The vectors will go in the direction they are pointing in";
    private string Part8 = "And if they hit another vector,        well,   you don't know what a physics reaction can do!";
    private float typingSpeed = 0.05f;
    private bool isTyping = false;

    [SerializeField] int currentIndex = 0;

    private List<string> dialogSteps = new List<string>();

    void Awake()
    {
        dialogSteps.Add(Part1);
        dialogSteps.Add(Part2);
        dialogSteps.Add(Part3);
        dialogSteps.Add(Part4);
        dialogSteps.Add(Part5);
        dialogSteps.Add(Part6);
        dialogSteps.Add(Part7);
        dialogSteps.Add(Part8);
    }

    void Start()
    {
        StartCoroutine(TypeText(dialogSteps[currentIndex]));
    }

    IEnumerator TypeText(string fullText)
    {
        textDisplay.text = "";

        foreach (char letter in fullText.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            isTyping = true;
        }

        isTyping = false;
    }

    void Update()
    {
        if (isTyping)
        {
            NextButtonText.color = new Color32(0, 0, 0, 0);
        }

        else
        {
            NextButtonText.color = new Color32(0, 0, 0, 255);
        }

        if (currentIndex == dialogSteps.Count - 1)
        {
            NextButtonText.text = "Get Started";
        }

    }

    public void NextButton()
    {
        if (currentIndex < dialogSteps.Count - 1 && !isTyping)
        {
            currentIndex++;
            StartCoroutine(TypeText(dialogSteps[currentIndex]));
        }

        else if (currentIndex == dialogSteps.Count - 1 && !isTyping)
        {
            TutorialDone = true;
            CanavasTutorial.SetActive(false);
        }
    }


}


