using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ButtonManager : MonoBehaviour
{
    public UserInputScript userInput;
    [SerializeField] bool StartMovingRight;
    [SerializeField] bool StartMovingBack;
    [SerializeField] bool Goback;
    [SerializeField] float moveSpeed;
    [SerializeField] float MaxXRight;
    [SerializeField] float finalXRight;
    [SerializeField] float MaxXLeft;
    [SerializeField] Transform SizePanel;

    void Start()
    {

    }


    void Update()
    {
        // if (StartMovingRight)
        // {
        //     SizePanel.localPosition += Vector3.right * moveSpeed * Time.deltaTime;

        //     if (SizePanel.localPosition.x > MaxX)
        //     {
        //         Goback = true;
        //         StartMovingRight = false;
        //     }
        // }

        // if (Goback)
        // {
        //     moveSpeed = 40f;

        //     SizePanel.localPosition += Vector3.left * moveSpeed * Time.deltaTime;

        //     if (SizePanel.localPosition.x < finalX)
        //     {
        //         Goback = false;
        //     }

        // }

        Moving(ref StartMovingRight, true, MaxXRight, finalXRight, Vector3.right, () => SizePanel.localPosition.x > MaxXRight);
        Moving(ref StartMovingBack, false, MaxXLeft, 0f /* doesn't matter */, Vector3.left, () => SizePanel.localPosition.x < MaxXLeft);
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(0);
    }

    public void TutorialBool()
    {
        Invoke("LoadTutorial", 0.5f);
    }

    public void AskSize()
    {
        StartMovingRight = true;
    }

    public void Back()
    {
        StartMovingBack = true;
    }

    public void LoadRLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void RLevelButton()
    {
        if (userInput.TookInput)
        {
            Invoke("LoadRLevel", 0.5f);
        }

        else
        {
            StartCoroutine(userInput.FlashPlaceholderError());
        }

    }

    void Moving(ref bool StartMoving, bool Step2nd, float MaxX, float finalX, Vector3 Direction, Func<bool> touchedMax)
    {
        if (StartMoving)
        {
            SizePanel.localPosition += Direction * moveSpeed * Time.deltaTime;

            if (touchedMax())
            {
                if (Step2nd)
                {
                    Goback = true;
                    Step2nd = false;
                }

                StartMoving = false;
            }
        }

        if (Goback)
        {
            moveSpeed = 40f;

            SizePanel.localPosition += Vector3.left * moveSpeed * Time.deltaTime;

            if (SizePanel.localPosition.x < finalX)
            {
                Goback = false;
            }

        }
    }


}
