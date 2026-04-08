using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ButtonManager : MonoBehaviour
{
    public UserInputScript userInput;
    [SerializeField] bool StartMovingRightFor2d;
    [SerializeField] bool StartMovingLefttFor3d;
    [SerializeField] bool StartMovingBackFor2d;
    [SerializeField] bool StartMovingBackFor3d;
    [SerializeField] bool Goback;
    [SerializeField] float moveSpeed;
    [SerializeField] float MaxXRightFor2D;
    [SerializeField] float MaxXLeftFor3D;
    [SerializeField] float finalXLeftFor3D;
    [SerializeField] float finalXRightFor2D;
    [SerializeField] float MaxXLeftFor2D;
    [SerializeField] float MaxXRightFor3D;
    [SerializeField] Transform SizePanel2d;
    [SerializeField] Transform SizePanel3d;

    void Start()
    {

    }


    void Update()
    {
        Moving(ref StartMovingRightFor2d, true, finalXRightFor2D, Vector3.right, () => SizePanel2d.localPosition.x > MaxXRightFor2D, SizePanel2d);
        Moving(ref StartMovingLefttFor3d, true, finalXLeftFor3D, Vector3.left, () => SizePanel3d.localPosition.x < MaxXLeftFor3D, SizePanel3d);
        Moving(ref StartMovingBackFor2d, false, 0f /* doesn't matter */, Vector3.left, () => SizePanel2d.localPosition.x < MaxXLeftFor2D, SizePanel2d);
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(0);
    }

    public void TutorialBool()
    {
        Invoke("LoadTutorial", 0.5f);
    }

    public void AskSizeFor2D()
    {
        StartMovingRightFor2d = true;
    }

    public void AskSizeFor3D()
    {
        StartMovingLefttFor3d = true;
    }

    public void BackFor2d()
    {
        StartMovingBackFor2d = true;
    }

    public void BackFor3d()
    {
        StartMovingBackFor3d = true;
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

    void Moving(ref bool StartMoving, bool Step2nd, float MaxX, float finalX, Vector3 Direction, Func<bool> touchedMax, Transform SizePanel)
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
