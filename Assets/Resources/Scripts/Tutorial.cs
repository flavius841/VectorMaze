using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;


public class Tutorial : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] string Part1 = "Welcome!";
    [SerializeField] string Part2 = "In this tutorial, you will learn how to solve a Vector Maze.";
    [SerializeField] string Part3 = "Don't worry, it's not as hard as it sounds!";
    [SerializeField] string Part4 = "The main goal of the game is to get rid of all the vectors in the maze.";
    [SerializeField] string Part5 = "Just click on them";
    [SerializeField] string Part6 = "But...";
    [SerializeField] string Part7 = "Be careful!   The vectors will go in the direction they are pointing in";
    [SerializeField] string Part8 = "And if they hit another vector,        well,    you don't know what a physics reaction can do!";
    private float typingSpeed = 0.05f;

    private List<string> dialogSteps = new List<string>();
    private int currentIndex = 0;

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

    IEnumerator TypeText(string fullText)
    {
        textDisplay.text = "";

        foreach (char letter in fullText.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    string GetPartText(int partNumber)
    {
        switch (partNumber)
        {
            case 0: return Part1;
            case 1: return Part2;
            case 2: return Part3;
            case 3: return Part4;
            case 4: return Part5;
            case 5: return Part6;
            case 6: return Part7;
            case 7: return Part8;
            default: return "";
        }
    }


    void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            StartCoroutine(TypeText(GetPartText(i)));
        }

    }
}


