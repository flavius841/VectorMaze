using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Tutorial : MonoBehaviour
{
    public bool TutorialDone = false;
    public ScoreScript scoreScript;
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] TextMeshProUGUI NextButtonText;
    [SerializeField] GameObject TutorialPanel;

    private string Part1 = "Welcome!";
    private string Part2 = "In this tutorial, you will learn how to solve a Vector Maze.";
    private string Part3 = "Don't worry, it's not as hard as it sounds!";
    private string Part4 = "The main goal of the game is to get rid of all the vectors in the maze.";
    private string Part5 = "Just click on them";
    private string Part6 = "But...";
    private string Part7 = "Be careful!   The vectors will go in the direction they are pointing in";
    private string Part8 = "And if they hit another vector,        well,   you don't know what a physics reaction can do!";
    private string Part9 = "Great!";
    private string Part10 = "You've nailed it!";
    private string Part11 = "Now, just a quick tip:";
    private string Part12 = "You can move the camera around by dragging the background with the right mouse button, and zoom in and out with the scroll wheel.";
    private float typingSpeed = 0.05f;
    private bool isTyping = false;
    private bool firstpartDone = false;

    [SerializeField] int currentIndex1 = 0;
    [SerializeField] int currentIndex2 = 0;

    private List<string> dialogSteps1 = new List<string>();
    private List<string> dialogSteps2 = new List<string>();

    void Awake()
    {
        dialogSteps1.Add(Part1);
        dialogSteps1.Add(Part2);
        dialogSteps1.Add(Part3);
        dialogSteps1.Add(Part4);
        dialogSteps1.Add(Part5);
        dialogSteps1.Add(Part6);
        dialogSteps1.Add(Part7);
        dialogSteps1.Add(Part8);

        dialogSteps2.Add(Part9);
        dialogSteps2.Add(Part10);
        dialogSteps2.Add(Part11);
        dialogSteps2.Add(Part12);
    }

    void Start()
    {
        StartCoroutine(TypeText(dialogSteps1[currentIndex1]));
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

        if (currentIndex1 == dialogSteps1.Count - 1 && !scoreScript.StartFinalTutorial)
        {
            NextButtonText.text = "Get Started";
        }

        else if (currentIndex2 == dialogSteps2.Count - 1 && scoreScript.StartFinalTutorial)
        {
            textDisplay.fontSize = 4;
            NextButtonText.text = "Menu";
        }

        else
        {
            NextButtonText.text = "Next";
        }

        if (scoreScript.StartFinalTutorial && currentIndex2 == 0 && !firstpartDone)
        {
            StartCoroutine(TypeText(dialogSteps2[currentIndex2]));
            firstpartDone = true;
        }
    }

    public void NextButton()
    {
        if (scoreScript.StartFinalTutorial)
        {
            if (currentIndex2 < dialogSteps2.Count - 1 && !isTyping)
            {
                currentIndex2++;
                StartCoroutine(TypeText(dialogSteps2[currentIndex2]));
            }

            else if (currentIndex2 == dialogSteps2.Count - 1 && !isTyping)
            {
                TutorialDone = true;
                TutorialPanel.SetActive(false);
            }

            if (NextButtonText.text == "Menu")
            {
                BackButton();
            }

        }

        else if (currentIndex1 < dialogSteps1.Count - 1 && !isTyping)
        {
            currentIndex1++;
            StartCoroutine(TypeText(dialogSteps1[currentIndex1]));
        }

        else if (currentIndex1 == dialogSteps1.Count - 1 && !isTyping)
        {
            TutorialDone = true;
            TutorialPanel.SetActive(false);
        }

    }

    public void BackButton()
    {
        Invoke("BackToMenu", 1f);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void RestartButton()
    {
        Invoke("RestartScene", 1f);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}


